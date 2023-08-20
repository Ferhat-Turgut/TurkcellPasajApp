

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class SellerProfileDisplayResponseDto
    {
        public SellerDisplayResponseDto Seller { get; set; }
        public IEnumerable<ProductDisplayResponseDto> Products { get; set; }
        public IEnumerable<OrderDetailsDisplayResponseDto> OrderDetails { get; set; }
    }
}
