using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class OrderViewModel
    {
        public BasketDisplayResponseDto Basket { get; set; }
        public CustomerDisplayResponseDto Customer { get; set; }
    }
}
