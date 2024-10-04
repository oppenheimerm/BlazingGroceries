using BG.Products.API.Data;
using BG.Products.API.Interfaces;
using BG.Shared;
using BG.Shared.APIResponse;
using BG.Shared.APIServiceLogs;
using BG.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BG.Products.API.Repositories
{
    public class ProductRepository(ProductDataContext context) : IProduct
    {
        public async Task<Response> CreateAsync(Product entity)
        {
            try {
                //  Validation if exist
                var productExist = await GetByAsync(_ => _.Title!.Equals(entity.Title));
                if (productExist is not null && !string.IsNullOrEmpty(productExist.Title))
                    return new Response(false, $"{entity.Title} already exist");

                var item = context.Products.Add(entity).Entity;
                await context.SaveChangesAsync();
                if(item is not null && item.Id > 0)
                {
                    return new Response(true, $"{entity.Title} added to databast at {DateTime.UtcNow.ToString()}");
                }
                else
                {
                    return new Response(false, $"{AppConstants.ErrorOccuredExecutingAddRequest} {entity.Title} {DateTime.UtcNow.ToString()}");
                }
            }
            catch(Exception ex)
            {
                //  Log original exception
                LogException.LogExceptions(ex);

                // Display friendly message to client
                return new Response(false, AppConstants.ErrorOccuredExecutingAddRequest + " " + DateTime.UtcNow.ToString());
            }
        }

        public async Task<Response> DeleteAsync(Product entity)
        {
            try {
                var item = await FindByIdAsync(entity.Id);
                if (item is null)
                {
                    return new Response(false, $"{entity.Id} not found");
                }

                // Remove entity
                context.Products.Remove(item);
                await context.SaveChangesAsync();

                return new Response(true, $"{AppConstants.SuccessfullyDeletedEntity} {entity.Title} {DateTime.UtcNow.ToString()}");
            }
            catch(Exception ex) {
                //  Log original exception
                LogException.LogExceptions(ex);

                // Display friendly message to client
                return new Response(false, AppConstants.ErrorOccuredExecutingDeleteRequest + " " + DateTime.UtcNow.ToString());
            }
        }

        public async Task<Product> FindByIdAsync(int Id)
        {
            try {
                var item = await context.Products.FindAsync(Id);
                return item is not null ? item : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
        }

        /// <summary>
        /// Not Used as id's are ints   
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Product> FindByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try {
                var items = await context.Products.AsNoTracking().ToListAsync();
                return items is not null ? items : null!;
            }
            catch (Exception ex){
                LogException.LogExceptions(ex);
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
        }

        public async Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate)
        {
            try
            {
                var items = await context.Products.Where(predicate).FirstOrDefaultAsync()!;
                return items is not null ? items : null!;
            }
            catch(Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception(AppConstants.ErrorRetrievingEntity);
            }
            
        }

        public async Task<Response> UdateAsync(Product entity)
        {
            try {
                var item = await FindByIdAsync(entity.Id);
                if (item is null)
                    return new Response(false, $"{entity.Title} Not found");

                context.Entry(item).State = EntityState.Deleted;
                context.Products.Update(entity);
                await context.SaveChangesAsync();
                return new Response(true, $"{entity.Title} updated. {DateTime.UtcNow.ToString()}");

            }
            catch(Exception ex){

                LogException.LogExceptions(ex);
                return new Response(false, AppConstants.ErrorUpdatingEntity);

            }
        }
    }
}
