using BG.Orders.API.Domain.DTO;

namespace BG.Orders.API.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrderByClientId(Guid Id);
        Task<OrderDetailsDTO> GetOrderDetails(int orderId);        
    }
}
