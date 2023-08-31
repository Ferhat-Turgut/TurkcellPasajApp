
namespace TurkcellPasajApp.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
    }
}
