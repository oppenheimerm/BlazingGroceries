using BG.Products.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BG.Products.API.Data
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
    }

    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ProductDataContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }

    public static class DbInitializer
    {
        public static void Initialize(ProductDataContext context)
        {
            if (context.Products.Any())
                return;

            var categories = new List<Category>
            {
                new Category { Id = "BAKE", Title = "Bakery", Image = "bakery.jpg"},
                new Category { Id = "MTFS", Title = "Meat and Fish", Image = "meatfish.jpg"},
                new Category { Id = "FTVG", Title = "Fresh Fruit and Vegetables", Image = "frutveg.jpg"},
                new Category { Id = "HLBY", Title = "Health and Beauty", Image = "helthbeauty.jpg"},
                new Category { Id = "CNPK", Title = "Canned, Tinned & Packaged Food", Image = "cantinpkg-food.jpg"},
                new Category { Id = "SNAK", Title = "Snaks", Image = "snaks.pg"},
                new Category { Id = "EDCL", Title = "Dairy, Eggs and Chilled", Image = "dareggchill.jpg"},
            };
            context.AddRange(categories);
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Title = "White Farmhouse Loaf 800g", CategoryId = "BAKE", Price = 1.45m, Image = "white-farmhouse-loaf-800g.jpg"},
                new Product { Title = "Multiseed Loaf 800g", CategoryId = "BAKE", Price = 1.20m, Image = "multiseed-loaf-800g.jpg"},
                new Product { Title = "Brown Sourdough 400g", CategoryId = "BAKE", Price = 2.10m, Image = "brown-sourdough-400g"},
                new Product { Title = "White Sourdough 400g", CategoryId = "BAKE", Price = 2.25m, Image = "white-sourdough-400g.jpg"},


                new Product { Title = "Cod Fillet 500g", CategoryId = "MTFS", Price = 10.5m, Image = "cod-fillet-500g.jpg"},
                new Product { Title = "Sea Bass Fillets 500g", CategoryId = "MTFS", Price =13.5m , Image = "sea-bass-500g.jpg"},
                new Product { Title = "Salmon Side 1-1.2kg ", CategoryId = "MTFS", Price = 30.25m, Image = "salmon-side-1-2kg.jpg"},
                new Product { Title = "Tiger Prawns 800g", CategoryId = "MTFS", Price = 27.0m, Image = "tiger-prawns-800g.jpg"},
                new Product { Title = "Flat Brisket 1 x 1kg", CategoryId = "MTFS", Price = 17.50m, Image = "flat-brisket-1kg.jpg"},
                new Product { Title = "Hand Pressed Steak & Bone Marrow Burger(2 x 150g)", CategoryId = "MTFS", Price = 6.95m, Image = "hand-pressed-steak-burger.jpg"},
                new Product { Title = "Rump Steak ( 2 x200g)", CategoryId = "MTFS", Price = 18.0m, Image = "rump-steak-200g.jpg"},
                new Product { Title = "Grass Fed Beef Mince 500g" , CategoryId = "MTFS", Price = 8.95m, Image = "grass-fed-beef-mince.jpg"},
                new Product { Title = "Whole Chicken 1.4kg" , CategoryId = "MTFS", Price = 14.95m, Image = "whole-chicken,jpg"},
                new Product { Title = "Chicken Thighs Skinned & Boned (4 x 75g)", CategoryId = "MTFS", Price = 8.95m, Image = "chicken-thighs.jpg"},
                new Product { Title = "7 Day Dry Aged Mini Rib Lamb Rack (1 x 300g)" , CategoryId = "MTFS", Price = 16.95m, Image = "mini-lamb-rib.jpg"},
                new Product { Title = "7 Day Dry Aged Lamb Shoulder (1 x 2kg)" , CategoryId = "MTFS", Price = 45.0m, Image = "lamb-shoulder.jpg"},

                new Product { Title = "Victorian Plums", CategoryId = "FTVG", Price = 0.41m, Image = "plums.jpg"},
                new Product { Title = "Flat White Peaches", CategoryId = "FTVG", Price = 0.99m, Image = "peaches.jpg",  InSeason = false},
                new Product { Title = "Italian Yellow Nectarines, (x 10)", CategoryId = "FTVG", Price = 12.95m, Image = "yellow-nectarines.jpg"},
                new Product { Title = "Thai Asparagus, (3 x 100g)", CategoryId = "FTVG", Price = 10.95m, Image = "italian-asparagus.jpg"},
                new Product { Title = "Baby Carrots, Purple, (x 3 Bunches)", CategoryId = "FTVG", Price = 13.95m, Image = "purple-baby-carrots.jpg"},
                new Product { Title = "Baking Potato (500g)", CategoryId = "FTVG", Price = 0.99m, Image = "baking-potato.jpg"},
                new Product { Title = "Loose Carrot (500g) ", CategoryId = "FTVG", Price = 0.99m, Image = "loose-carrots.jpg"},
                new Product { Title = "Loose Shallots Onion (500g) ", CategoryId = "FTVG", Price = 1.99m, Image = "loose-shallots.jpg"},
                new Product { Title = "Loose White Onion (1kg) ", CategoryId = "FTVG", Price = 1.99m, Image = "loose-white-onion.jpg"},
                new Product { Title = "Loose Red Onion (1kg) ", CategoryId = "FTVG", Price = 1.99m, Image = "loose-red-onion.jpg"},
                new Product { Title = "Braeburn Apple (1 x)", CategoryId = "FTVG", Price = 0.55m, Image = "braeburn-apple.jpg"},
                new Product { Title = "Granny Smith Apple (1 x) ", CategoryId = "FTVG", Price = 0.70m, Image = "granny-smith-apple.jpg"},
                new Product { Title = "Plum Cherry Tomato (500g)", CategoryId = "FTVG", Price = 4.99m, Image = "cherry-tomato.jpg"},
                new Product { Title = "Sweet Potato  (1 kg)", CategoryId = "FTVG", Price = 2.99m, Image = "sweet-potato.jpg"},


                new Product { Title = "Sweet Potato  (1 kg)", CategoryId = "FTVG", Price = 2.99m, Image = "sweet-potato.jpg"},
               

                new Product { Title = "Radox Mineral Therapy Feel Radiant Shower Gel 225ml", CategoryId = "HLBY", Price = 2.99m, Image = "radox-feel-radiant.jpg"},
                new Product { Title = "NIVEA Shower Cream Gel, Indulgent Moisture Coconut, 250ml", CategoryId = "HLBY", Price = 1.30m, Image = "nivea-shower-cream-gel-coconut.jpg"},
                

                /*new Models.Product { Title = "", , CategoryId = "", Price = , Image = ""},*/

            };
            context.AddRange(products);
            context.SaveChanges();
        }
    }
}
