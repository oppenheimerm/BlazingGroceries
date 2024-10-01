using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BG.Products.API.Domain.DTO
{
    //  simplify with the use of recorda
    public record CategoryDTO
    (
        [Required, MaxLength(4, ErrorMessage = "Category id must be 4 characters long"), MinLength(4)] string Id,

        [Required, StringLength(50)] string Title,

        [Required] string Image
    );
}
