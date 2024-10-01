using BG.Products.API.Domain.DTO;
using BG.Products.API.Domain.Entities;

namespace BG.Products.API.Domain
{
    public static class ModelHelper
    {
        public static Category ToEntity(this CategoryDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            else
            {
                return new Category
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Image = dto.Image
                };
            }
        }

        public static Product ToEntity(this ProductDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            else
            {
                return new Product
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Price = dto.Price,
                    Image = dto.Image,
                    InSeason = dto.InSeason,
                    CategoryId = dto.CategoryId
                };
            }
        }



        public static (CategoryDTO?, IEnumerable<CategoryDTO>?) FromEntity(Category category, IEnumerable<Category>? categories)
        {
            // Return single
            if(category is not null || categories is null)
            {
                var singleCategory = new CategoryDTO(
                        category!.Id!,
                        category!.Title!,
                        category!.Image!
                    );

                return (singleCategory, null);
            }

            // Retun IEnumerable<T> list
            if(categories is not null || category is null)
            {
                var _categories = categories!.Select(c =>
                    new CategoryDTO(c.Id!, c.Title!, c.Image!)).ToList();

                return (null, _categories);
            }

            return (null, null);
        }

        public static (ProductDTO?, IEnumerable<ProductDTO>?) FromEntity(Product product, IEnumerable<Product>? products)
        {
            // Return single
            if (product is not null || products is null)
            {
                var singleProduct = new ProductDTO(
                        product!.Id!,
                        product!.Title!,
                        product.Price!.Value,
                        product!.Image!,
                        product!.ImageUrl!,
                        product!.InSeason,
                        product!.CategoryId!
                    );

                return (singleProduct, null);
            }

            // Retun IEnumerable<T> list
            if (products is not null || product is null)
            {
                var _products = products!.Select(p =>
                    new ProductDTO(p.Id!, p.Title!, p.Price!.Value, p.Image!, p.ImageUrl!, p.InSeason, p.CategoryId!)).ToList();

                return (null, _products);
            }

            return (null, null);
        }
    }
}
