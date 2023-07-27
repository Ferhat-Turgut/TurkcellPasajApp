using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class OrderDetail 
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
       
        [Required]
        public int OrderProductId { get; set; }
        public Product OrderProduct { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
