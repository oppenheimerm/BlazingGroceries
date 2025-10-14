using BG.Models;

namespace BG.Helpers
{
    public interface IUIHelpers
    {
        /// <summary>
        /// Returns the list of categories
        /// </summary>
        /// <returns></returns>
        List<Category> GetCategories();

        /// <summary>
        /// Returns a <see cref="Category"/> by categoryCode
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        Category? GetSCategoryByCode(string? categoryCode);
    }

    public class UIHelpers : IUIHelpers
    {
        public Category? GetSCategoryByCode(string? categoryCode)
        {
            var query = GetCategories().
                Where(c => c.CategoryCode == categoryCode)
                .FirstOrDefault();

            return query ?? null;
        }

        public List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    CategoryCode = "ALCL",
                    CategoryName = "Alcohol",
                    CategoryImage = "alcohol.jpg"
                },
                new Category
                {
                    CategoryCode = "BAKE",
                    CategoryName = "Bakery",
                    CategoryImage = "bakery.jpg"
                },
                new Category
                {
                    CategoryCode = "DAIRY",
                    CategoryName = "Dairy",
                    CategoryImage = "dairy.png"
                },
                new Category
                {
                    CategoryCode = "FTVG",
                    CategoryName = "Fruit & Vegetable",
                    CategoryImage = "fruitandveg.png"
                },
                new Category
                {
                    CategoryCode = "BUTR",
                    CategoryName = "Butcher",
                    CategoryImage = "butcher.png"
                },
                new Category
                {
                    CategoryCode = "BVGS",
                    CategoryName = "Beverages",
                    CategoryImage = "beverages.png"
                },
                new Category
                {   
                    CategoryCode = "LUCL",
                    CategoryName = "Laundry & Cleaning",
                    CategoryImage = "laundryandcleaning.png"
                }
            };
        }
    }
}
