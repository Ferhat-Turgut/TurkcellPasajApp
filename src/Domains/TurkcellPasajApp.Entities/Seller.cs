using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Seller : IdentityUser<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Address { get; set; }
       

        // Products navigasyonunu ekleyin ve SellerId'yi foreign key olarak belirtin
        public List<Product> Products { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Message>? Messages { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
