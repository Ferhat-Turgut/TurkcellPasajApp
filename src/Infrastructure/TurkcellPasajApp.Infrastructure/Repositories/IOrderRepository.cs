using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order>? GetAll();
        Task<IEnumerable<Order>>? GetAllAsync();

        IEnumerable<Order>? GetAllByCustomerId(int customerId);
        Task<IEnumerable<Order>>? GetAllByCustomerIdAsync(int customerId);
        IEnumerable<Order>? GetAllBySellerId(int sellerId);
        Task<IEnumerable<Order>>? GetAllBySellerIdAsync(int sellerId);
        Task<int> CreateOrderAndReturnIdAsync(Order order);
        int CreateOrderAndReturnId(Order order);
    }
}
