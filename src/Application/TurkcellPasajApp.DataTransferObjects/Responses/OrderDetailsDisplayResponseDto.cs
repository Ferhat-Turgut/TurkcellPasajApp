

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class OrderDetailsDisplayResponseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDisplayResponseDto Order { get; set; }
        public int OrderDetailsProductId { get; set; }
        public ProductDisplayResponseDto OrderDetailsProduct { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
      
    }
}
