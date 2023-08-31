using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.DataTransferObjects.Requests
{
    public class CreateNewBasketRequestDto
    {
        public int CustomerId { get; set; }
        public int Amount { get; set; }
    }
}
