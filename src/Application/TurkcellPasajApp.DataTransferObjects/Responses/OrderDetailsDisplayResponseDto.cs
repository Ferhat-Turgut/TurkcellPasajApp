

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class OrderDetailsDisplayResponseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
    }
}
