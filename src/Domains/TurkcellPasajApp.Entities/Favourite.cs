using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.Entities
{
    public class Favourite 
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int FavouriteProductId { get; set; }
        public Product FavouriteProduct { get; set; }
        [Required]
        public bool IsFavourite { get; set; }
    }
}
