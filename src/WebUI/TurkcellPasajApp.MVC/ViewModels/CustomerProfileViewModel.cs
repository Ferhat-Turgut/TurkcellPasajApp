using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class CustomerProfileViewModel
    {
        public CustomerDisplayResponseDto Customer { get; set; }
        public IEnumerable<OrderDisplayResponseDto>? Orders { get; set; }
        public IEnumerable<ProductDisplayResponseDto>? FavouriteProducts { get; set; }
    }
}
