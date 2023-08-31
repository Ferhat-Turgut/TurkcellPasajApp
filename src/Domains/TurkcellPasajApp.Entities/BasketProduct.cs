namespace TurkcellPasajApp.Entities
{
    public class BasketProduct
    {
        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
