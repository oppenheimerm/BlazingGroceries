using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BG.Orders.API.Domain.Entities
{
    public class BGUser
    {
        [Required]
        [Key]
        public Guid? Id { get; set; }

        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")]
        public string? FirstName { get; set; }

        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")]
        public string? LastName { get; set; }


        [Required, MaxLength(256, ErrorMessage = "Max length of 256 characters.")]
        public string? Address { get; set; }

        [Required]
        public string? TelephoneNumber { get; set; }


        [Required, MaxLength(10, ErrorMessage = "Max length of 10 characters.")]
        public string? PostCode { get; set; }


        [Required]
        public string? Password {get; set; }

        [Required, MaxLength(25, ErrorMessage = "Max length of 25 characters.")] 
        public string? Role { get; set; }
    }
}
