using System.ComponentModel.DataAnnotations;

namespace BG.Orders.API.Domain.DTO
{
    public record OrderDetailsDTO
    (
        [Required] int OrderId,
        [Required] int ProductId,
        [Required] Guid ClientId,
        [Required, EmailAddress] string EmailAddress,
        [Required] string TelephoneNumber,
        [Required] string ProductTitle,
        [Required] int Quantity,
        [Required, DataType(DataType.Currency)] decimal UnitPrice,
        [Required, DataType(DataType.Currency)] decimal TotalPrice,
        [Required] DateTime OrderDate
    );
}
