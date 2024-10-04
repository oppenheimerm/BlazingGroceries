
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BG.Shared.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ImageUrl = AppConstants.productBaseUrl + Image;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "The title field has a max length of 200 characters.")]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [MaxLength(256, ErrorMessage = "Image file name cannot exceed 256 characters.")]
        public string? Image { get; set; }

        public string? ImageUrl { get; }

        public bool InSeason { get; set; } = true;

        [Required]
        [ForeignKey(nameof(Category))]
        public string? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
