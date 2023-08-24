

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class CustomerProfileDisplayResponseDto
    {
        public CustomerDisplayResponseDto Customer { get; set; }
        public IEnumerable<ProductDisplayResponseDto> FavouriteProducts { get; set; }
        public IEnumerable<OrderDisplayResponseDto> Orders { get; set; }
    }
}
