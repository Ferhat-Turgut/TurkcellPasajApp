using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Order 
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

       
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
