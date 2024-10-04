using System.ComponentModel.DataAnnotations;

namespace BG.Orders.API.Domain.DTO
{
    public record OrderDTO
        (
            [Required] int Id,
            [Required] int ProductId,
            [Required] Guid UserId,
            [Required, MaxLength(200, ErrorMessage = "The product title field has a max length of 200 characters.")] string ProductTitle,
            [Required, DataType(DataType.Currency)] decimal Price,
            string ProductImageUrl,
            [Required] int Quantity,
            [Required] DateTime Timestamp
        );

}
