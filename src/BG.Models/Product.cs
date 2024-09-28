
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BG.Models
{
    public class Product
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "The title field has a max length of 200 characters.")]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [MaxLength(200, ErrorMessage = "Image file name cannot exceed 50 characters.")]
        public string? Image { get; set; }

        public bool InSeason { get; set; } = true;

        [Required]
        [ForeignKey(nameof(Category))]
        public string? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
