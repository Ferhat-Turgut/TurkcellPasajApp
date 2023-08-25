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


        public IEnumerable<Product>? Products { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Message>? Messages { get; set; }
        public IEnumerable<OrderDetail>? SellersOrderDetails { get; set; }
    }
}
