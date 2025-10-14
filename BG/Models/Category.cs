using System.ComponentModel.DataAnnotations;

namespace BG.Models
{
    public class Category
    {
        [Required]
        [MaxLength(4, ErrorMessage = "CategoryCode must be 4 characters long"), MinLength(4)]
        public string? CategoryCode { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        public string? CategoryImage { get; set; }
    }
}
