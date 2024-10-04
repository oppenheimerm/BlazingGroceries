using BG.Shared.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BG.Orders.API.Domain.Entities
{
    public class Order
    {

        [Key]
        public int? Id { get; set; }


        [Required]
        public int? ProductId { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "The title field has a max length of 200 characters.")]
        public string? ProductTitle { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public string? ProductImageUrl { get; set; }

        [Required]
        public int? Quantity { get; set; }
        public DateTime Timestamp { get; set;  } = DateTime.UtcNow;
    }
}
