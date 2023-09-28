using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class AddProductViewModel
    {
        public CreateNewProductRequestDto? CreateProduct { get; set; }
        public IEnumerable<CategoryDisplayResponseDto>? Categories { get; set; }
    }
}
