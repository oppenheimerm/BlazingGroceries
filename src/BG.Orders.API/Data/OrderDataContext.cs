using BG.Orders.API.Domain.Entities;
using BG.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BG.Orders.API.Data
{
    public class OrderDataContext(DbContextOptions<OrderDataContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
    }

    public static class DbInitializer
    {
        public static void Initialize(OrderDataContext context)
        {
            if (context.Orders.Any())
                return;

            var orders = new List<Order>
            { 
                new Order { ProductId = 1, UserId = Guid.Parse("03644b7f-56b3-4b12-ab98-621a809edcbd"), ProductTitle = "White Farmhouse Loaf 800g", Price = 1.45m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 2 , Timestamp = new DateTime(2024, 01, 03) },
                new Order { ProductId = 6, UserId = Guid.Parse("03644b7f-56b3-4b12-ab98-621a809edcbd"), ProductTitle = "Sea Bass Fillets 500g", Price = 1.5m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 01, 03) },
                new Order { ProductId = 8, UserId = Guid.Parse("03644b7f-56b3-4b12-ab98-621a809edcbd"), ProductTitle = "Tiger Prawns 800g", Price = 27.0m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 01, 03) },
                new Order { ProductId = 18, UserId = Guid.Parse("03644b7f-56b3-4b12-ab98-621a809edcbd"), ProductTitle = "Flat White Peaches", Price = 0.99m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 3, Timestamp = new DateTime(2024, 01, 03) },

                new Order { ProductId = 33, UserId = Guid.Parse("70bb7422-add4-4720-a951-87fc81b2f0da"), ProductTitle = "NIVEA Shower Cream Gel, Indulgent Moisture Coconut, 250ml", Price = 1.30m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 2, Timestamp = new DateTime(2024, 04, 19) },
                new Order { ProductId = 28, UserId = Guid.Parse("70bb7422-add4-4720-a951-87fc81b2f0da"), ProductTitle = "Granny Smith Apple (1 x)", Price = 0.7m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 4, Timestamp = new DateTime(2024, 04, 19) },
                new Order { ProductId = 29, UserId = Guid.Parse("70bb7422-add4-4720-a951-87fc81b2f0da"), ProductTitle = "Plum Cherry Tomato (500g)", Price = 4.99m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 2, Timestamp = new DateTime(2024, 04, 19) },
                new Order { ProductId = 26, UserId = Guid.Parse("70bb7422-add4-4720-a951-87fc81b2f0da"), ProductTitle = "Loose Red Onion (1kg)", Price = 1.99m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 04, 19) },
                new Order { ProductId = 21, UserId = Guid.Parse("70bb7422-add4-4720-a951-87fc81b2f0da"), ProductTitle = "Baby Carrots, Purple, (x 3 Bunches)", Price = 13.95m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 04, 19) },

                new Order { ProductId = 4, UserId = Guid.Parse("8716e3f9-3e24-4664-bc7c-1e7b7a9df2b2"), ProductTitle = "White Sourdough 400g", Price = 2.25m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 08, 26) },
                new Order { ProductId = 5, UserId = Guid.Parse("8716e3f9-3e24-4664-bc7c-1e7b7a9df2b2"), ProductTitle = "Cod Fillet 500g", Price = 10.5m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 08, 26) },


                new Order { ProductId = 27, UserId = Guid.Parse("0bacc512-9e8d-4841-a04a-d0cde5e77b11"), ProductTitle = "Braeburn Apple (1 x)", Price = 0.55m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 5, Timestamp = new DateTime(2024, 07, 23) },
                new Order { ProductId = 14, UserId = Guid.Parse("0bacc512-9e8d-4841-a04a-d0cde5e77b11"), ProductTitle = "Chicken Thighs Skinned & Boned (4 x 75g)", Price = 8.95m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 07, 23) },
                new Order { ProductId = 2, UserId = Guid.Parse("0bacc512-9e8d-4841-a04a-d0cde5e77b11"), ProductTitle = "Multiseed Loaf 800g", Price = 1.20m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 1, Timestamp = new DateTime(2024, 07, 23) },
                new Order { ProductId = 33, UserId = Guid.Parse("0bacc512-9e8d-4841-a04a-d0cde5e77b11"), ProductTitle = "NIVEA Shower Cream Gel, Indulgent Moisture Coconut, 250ml", Price = 1.30m, ProductImageUrl = "PRODUCT_IMAGE", Quantity = 2, Timestamp = new DateTime(2024, 07, 23) },
            };

            context.AddRange(orders);
            context.SaveChanges();
        }
    }
}
