using System.ComponentModel.DataAnnotations;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewFavouriteRequestDto
    {
       
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int FavouriteProductId { get; set; }
        [Required]
        public bool IsFavourite { get; set; }
    }
}
