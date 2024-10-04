using BG.Orders.API.Data;
using BG.Orders.API.Domain.Entities;
using BG.Orders.API.Interfaces;
using BG.Shared;
using BG.Shared.APIResponse;
using BG.Shared.APIServiceLogs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BG.Orders.API.Repositories
{
    public class OrderRepository(OrderDataContext context) : IOrder
    {
        public async Task<Response> CreateAsync(Order entity)
        {
            try {
                var order = context.Orders.Add(entity).Entity;
                await context.SaveChangesAsync();

                return order.Id > 0 ? new Response(true, AppConstants.SuccssfulOrder) : new Response(false, AppConstants.ErrorExecutingOrder);
            }
            catch(Exception ex) {
                LogException.LogExceptions(ex);

                //  Display friendly message
                return new Response(false, AppConstants.ErrorExecutingOrder);
            }
        }

        public async Task<Response> DeleteAsync(Order entity)
        {
            try
            {
                var query = await FindByIdAsync(entity.Id!.Value);
                if (query is null)
                    return new Response(false, AppConstants.OrderNotFound);

                context.Orders.Remove(entity);
                await context.SaveChangesAsync();
                return new Response(true, AppConstants.SuccessfullyDeletedEntity);

            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                return new Response(false, AppConstants.ErrorOccuredExecutingDeleteRequest);
            }
        }

        public async Task<Order> FindByIdAsync(int Id)
        {
            try
            {
                var order = await context.Orders.FindAsync(Id);
                return order is not null ? order : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                throw new Exception(AppConstants.ErrorExecutingOrder);
            }
        }


        //  Not used
        public Task<Order> FindByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                var orders = await context.Orders.AsNoTracking().ToListAsync();
                return orders is not null ? orders : null!;

            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
        }

        public async Task<Order> GetByAsync(Expression<Func<Order, bool>> predicate)
        {
            try
            {
                var order = await context.Orders.Where(predicate).FirstOrDefaultAsync();
                return order is not null ? order : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> predicate)
        {
            try
            {
                var orders = await context.Orders.Where(predicate).ToListAsync();
                return orders is not null ? orders : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
        }

        public async Task<Response> UdateAsync(Order entity)
        {
            try
            {
                var order = await FindByIdAsync(entity.Id!.Value);
                if (order is null)
                    return new Response(false, AppConstants.EntityNotFound);

                context.Entry(order).State = EntityState.Detached;
                context.Orders.Update(entity);
                await context.SaveChangesAsync();

                return new Response(true, $"{AppConstants.SuccessfullyUpdatedEntity} at {DateTime.UtcNow.ToLongDateString()}");

            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);

                //  Display friendly message
                return new Response(false, AppConstants.ErrorExecutingOrder);
            }
        }
    }
}
