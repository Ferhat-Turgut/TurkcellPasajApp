﻿using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
