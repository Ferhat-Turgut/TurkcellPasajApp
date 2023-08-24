namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class ProductDisplayResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public CategoryDisplayResponseDto Category { get; set; }
        public SellerDisplayResponseDto Seller { get; set; }
    }
}
