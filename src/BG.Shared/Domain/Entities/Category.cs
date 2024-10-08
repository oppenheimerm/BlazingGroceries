﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BG.Shared.Domain.Entities
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(4, ErrorMessage = "Category id must be 4 characters long"), MinLength(4)]
        public string? Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Image { get; set; }

        public ICollection<Category>? Products { get; set; }
    }
}
