using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetail>? GetOrderDetailByIdAsync(int orderDetailId);
        OrderDetail? GetOrderDetailById(int orderDetailId);
        Task<IEnumerable<OrderDetail>>? GetOrderDetailByOrderIdAsync(int orderId);
        IEnumerable<OrderDetail>? GetOrderDetailByOrderId(int orderId);
        void CreateNewOrderDetail(CreateNewOrderDetailRequestDto createNewOrderDetailRequest);
        Task CreateNewOrderDetailAsync(CreateNewOrderDetailRequestDto createNewOrderDetailRequest);
    }
}
