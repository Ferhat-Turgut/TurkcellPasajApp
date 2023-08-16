using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllByOrderId(int orderId);
        Task<IEnumerable<OrderDetail>> GetAllByOrderIdAsync(int orderId);
        //IEnumerable<OrderDetail> GetAllBySellerId(int sellerId);
        //Task<IEnumerable<OrderDetail>> GetAllBySellerIdAsync(int sellerId);

    }
}
