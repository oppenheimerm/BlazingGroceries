
using BG.Shared.APIResponse;
using System.Linq.Expressions;

namespace BG.Shared.Interface
{
    public interface IGenericInterface<T> where T : class
    {
        Task<Response> CreateAsync(T entity);
        Task<Response> UdateAsync(T entity);
        Task<Response> Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(int Id);
        Task<T> FindByIdAsync(Guid Id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }
}
