using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Product 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
