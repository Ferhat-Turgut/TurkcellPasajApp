namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class OrderDisplayResponseDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderDetailsDisplayResponseDto>? OrderDetails { get; set; }
    }
}
