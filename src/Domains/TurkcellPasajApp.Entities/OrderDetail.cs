using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class OrderDetail 
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int OrderProductId { get; set; }
        public Product OrderProduct { get; set; }

        public int OrderDetailsSellerId { get; set; }
        public Seller OrderDetailsSeller { get; set; } // Navigasyon özelliği
        [Required]
        public int Quantity { get; set; }
    }
}
