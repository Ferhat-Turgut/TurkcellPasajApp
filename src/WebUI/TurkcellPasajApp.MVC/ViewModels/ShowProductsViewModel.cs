using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class ShowProductsViewModel
    {
        public IEnumerable<ProductDisplayResponseDto>? Products { get; set; }
        public IEnumerable<FavouriteDisplayResponseDto>? Favourites { get; set; }
    }
}
