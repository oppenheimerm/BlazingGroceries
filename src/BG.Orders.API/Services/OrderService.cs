using BG.Orders.API.Domain;
using BG.Orders.API.Domain.DTO;
using BG.Orders.API.Interfaces;
using BG.Shared;
using BG.Shared.Domain.Entities.DTO;
using Polly;
using Polly.Registry;

namespace BG.Orders.API.Services
{
    /// <summary>
    /// Used to communicate with the external api(BG.Products.API), to retreive <see cref="BG.Shared.Domain.Entities.Product"/>
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="resiliencePipeline"></param>
    public class OrderService( IOrder orderInterface, HttpClient httpClient, 
        ResiliencePipelineProvider<string> resiliencePipeline) : IOrderService
    {
        //  Api product get request
        public async Task<ProductDTO> GetProduct(int productId)
        {
            //  Call Product Api using HttpClient
            //  Need to redirect to API Gateway
            httpClient.BaseAddress = new Uri("http://localhost:5001/");
            var productQuery = await httpClient.GetAsync($"/api/product/{productId}");
            //
            if (!productQuery.IsSuccessStatusCode)
                return null!;

            var product = await productQuery.Content.ReadFromJsonAsync<ProductDTO>();
            return product!;

        }

        //  TODO
        //  Api user get request
        public async Task<BGUserDTO> GetUser(Guid userId)
        {
            // NOT YET IMPLMENTED
            var userQuery = await httpClient.GetAsync($"{AppConstants.BASE_API_USER}{userId}");
            if (!userQuery.IsSuccessStatusCode)
                return null!;

            var user = await userQuery.Content.ReadFromJsonAsync<BGUserDTO>();
            return user!;
        }


        //  Api order by clients
        public async Task<IEnumerable<OrderDTO>> GetOrderByClientId(Guid Id)
        {
            var orders = await orderInterface.GetOrdersAsync(o => o.UserId == Id);
            if (!orders.Any()) return null!;

            var (_, _orders) = ModelHelper.FromEntity(null!, orders);
            return _orders!;
            
        }


        public async Task<OrderDetailsDTO> GetOrderDetails(int orderId)
        {
            //  Retrieve order
            var order = await orderInterface.FindByIdAsync(orderId);
            if (order is null || order!.Id <= 0)
                return null!;


            //  Get retry pipeline
            //  3 @ 51:44 
            var retryPipeline = resiliencePipeline.GetPipeline(AppConstants.RESILIENCE_PIPELINE);

            //  Retrieve Product
            var product = await retryPipeline.ExecuteAsync(async token => await GetProduct(order.ProductId!.Value));


            //  TODO - BG.User.API
            //  Client / user
            var bgUser = await retryPipeline.ExecuteAsync(async token => await GetUser(order.UserId!.Value));

            //  @ 3 / 2:09:32
            //  Build order details
            return new OrderDetailsDTO(
                order.Id!.Value,
                product.Id,
                Guid.Empty,
                "bgUser.EmailAddress",
                "bgUser.TelephoneNumber",
                product.Title,
                order.Quantity!.Value,
                product.Price,
                (order.Price!.Value * order!.Quantity.Value),
                order.Timestamp
                );

        }
    }
}
