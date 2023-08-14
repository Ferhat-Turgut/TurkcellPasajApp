using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class CustomerProfileViewModel
    {
        public CustomerDisplayResponseDto CustomerDisplayResponseDto { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public ShowProductsViewModel? showProductsViewModel { get; set; }
    }
}
