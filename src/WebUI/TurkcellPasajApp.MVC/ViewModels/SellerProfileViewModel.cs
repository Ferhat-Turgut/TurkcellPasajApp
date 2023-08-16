using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class SellerProfileViewModel
    {
        public IEnumerable<ProductDisplayResponseDto>? ProductDisplayResponseDto { get; set; }
        public SellerDisplayResponseDto SellerDisplayResponseDto { get; set; }
        public IEnumerable<OrderDetailsDisplayResponseDto>? orderDetailsDisplayResponseDtos { get; set; }
    }
}
