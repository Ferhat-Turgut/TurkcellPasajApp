namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class CreditCardDisplayResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal AvaibleBalance { get; set; }

    }
}
