using System.ComponentModel.DataAnnotations;

namespace BG.Orders.API.Domain.DTO
{
    public record BGUserDTO
    (
        [Required] Guid Id,
        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")] string FirstName,
        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")] string LastName,
        [Required, DataType(DataType.EmailAddress)] string EmailAddress,
        [Required, MaxLength(256, ErrorMessage = "Max length of 256 characters.")] string Address,
        [Required] string TelephoneNumber,
        [Required, MaxLength(10, ErrorMessage = "Max length of 10 characters.")] string PostCode,
        [Required] string Password,
        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")] string Role
    );
}
