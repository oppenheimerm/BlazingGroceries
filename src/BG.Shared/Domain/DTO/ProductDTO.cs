using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BG.Shared.Domain.Entities.DTO
{
    public record ProductDTO
    (
        [Required] int Id,

        [Required, MaxLength(200, ErrorMessage = "The title field has a max length of 200 characters.")] string Title,

        [Required, DataType(DataType.Currency)] decimal Price,

        [Required, MaxLength(200, ErrorMessage = "Image file name cannot exceed 50 characters.")] string Image,

        string ImageURL,

        bool InSeason,

        [Required] string CategoryId
    );
}
