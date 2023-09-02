using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewBasketProductRequestDto
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
