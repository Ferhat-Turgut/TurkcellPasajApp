
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class UpdateBasketProductsRequestDto
    {
        public int BasketId { get; set; }
        public BasketDisplayResponseDto Basket { get; set; }
        public int ProductId { get; set; }
        public ProductDisplayResponseDto Product { get; set; }
        public int Quantity { get; set; }

    }
}
