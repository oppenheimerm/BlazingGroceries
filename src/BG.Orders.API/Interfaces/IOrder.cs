using BG.Orders.API.Domain.Entities;
using BG.Shared.Interface;
using System.Linq.Expressions;

namespace BG.Orders.API.Interfaces
{
    public interface IOrder:IGenericInterface<Order> {
        /// <summary>
        /// Specialized Interface for all orders
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> predicate);
    }
}
