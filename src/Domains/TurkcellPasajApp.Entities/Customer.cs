using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Customer :IdentityUser<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        [Required]
        [MaxLength(300)]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
       

        public ICollection<Favourite>? Favourites { get; set; }
        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<CreditCard>? CreditCards { get; set; }
    }
}
