
namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class BasketProductsDisplayResponseDto
    {
        public int BasketId { get; set; }
        public BasketDisplayResponseDto Basket { get; set; }

        public int ProductId { get; set; }
        public ProductDisplayResponseDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
