using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class CreditCard 
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [MaxLength(50)]
        public string CardHolder { get; set; }
        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [MaxLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal AvaibleBalance { get; set; }

    }
}
