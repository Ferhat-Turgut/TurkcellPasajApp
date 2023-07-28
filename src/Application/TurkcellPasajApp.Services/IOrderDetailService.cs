using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetail>? GetOrderDetailByIdAsync(int orderDetailId);
        OrderDetail? GetOrderDetailById(int orderDetailId);
    }
}
