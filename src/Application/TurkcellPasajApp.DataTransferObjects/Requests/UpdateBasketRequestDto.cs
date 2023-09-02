
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateBasketRequestDto
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public CustomerDisplayResponseDto Customer { get; set; }
        public List<BasketProductsDisplayResponseDto> BasketProducts { get; set; }
    }
}
