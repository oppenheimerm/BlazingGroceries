using BG.Orders.API.Domain.Entities;
using BG.Orders.API.Domain.DTO;

namespace BG.Orders.API.Domain
{
    public static class ModelHelper
    {
        public static Order ToEntity(this OrderDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            else
            {
                return new Order
                {
                    Id = dto.Id,
                    ProductId = dto.ProductId,
                    ProductTitle = dto.ProductTitle,
                    Price = dto.Price,
                    ProductImageUrl = dto.ProductImageUrl,
                    Quantity = dto.Quantity,
                    Timestamp = dto.Timestamp
                };
            }
        }

        public static (OrderDTO?, IEnumerable<OrderDTO>?) FromEntity(Order order, IEnumerable<Order>? orders)
        {
            // Return single
            if (order is not null || orders is null)
            {
                var singleCategory = new OrderDTO(
                        order!.Id!.Value,
                        order!.ProductId!.Value,
                        order!.UserId!.Value,
                        order!.ProductTitle!,
                        order!.Price!.Value,
                        order!.ProductImageUrl!,
                        order!.Quantity!.Value,
                        order!.Timestamp
                    );

                return (singleCategory, null!);
            }

            // Retun IEnumerable<T> list
            if (orders is not null || order is null)
            {
                var _orders = orders!.Select(o =>
                    new OrderDTO(
                        o.Id!.Value!, o.ProductId!.Value, 
                        o.UserId!.Value!, o.ProductTitle!,
                        o.Price!.Value, o.ProductImageUrl!,
                        o.Quantity!.Value,
                        o.Timestamp)).ToList();

                return (null!, _orders);
            }

            return (null!, null!);
        }
    }
}
