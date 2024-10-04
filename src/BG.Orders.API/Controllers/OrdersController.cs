using Microsoft.AspNetCore.Mvc;
using BG.Orders.API.Domain;
using BG.Orders.API.Domain.DTO;
using BG.Orders.API.Interfaces;
using BG.Shared.APIResponse;
namespace BG.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrder ordersInterface, IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await ordersInterface.GetAllAsync();
            if (!orders.Any())
                return NotFound("No orders found");

            var (_, list) = ModelHelper.FromEntity(null!, orders);

            return !list!.Any() ? NotFound() : Ok(list);       
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await ordersInterface.FindByIdAsync(id);
            if (order is null)
                return NotFound(null);

            var (_order, _) = ModelHelper.FromEntity(order, null!);
            return Ok(_order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<OrderDTO>> GetOrderByCustomerId(Guid customerId)
        {
            var orders = await orderService.GetOrderByClientId(customerId);
            return !orders.Any() ? NotFound() : Ok(orders);
        }

        [HttpGet("details/{orderId:int}")]
        public async Task<ActionResult<OrderDetailsDTO>> GetOrderDetails(int orderId)
        {
            var orderDetails = await orderService.GetOrderDetails(orderId);
            //  UNNECCESSARY: return orderDetails.OrderId > 0 ?
            //return orderDetails.OrderId > 0 ? Ok(orderDetails) : NotFound("Order not found");
            return (orderDetails is not null)  ? Ok(orderDetails) : NotFound("Order not found");
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Melformed order request");

            var query = ModelHelper.ToEntity(orderDTO);
            var response = await ordersInterface.CreateAsync(query);
            return response.flag ? Ok(response) : BadRequest(response);
        }
    }
}
