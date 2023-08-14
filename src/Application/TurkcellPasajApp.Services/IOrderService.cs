using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>>? GetAllOrdersByCustomerIdAsync(int customerId);
        IEnumerable<Order>? GetAllOrdersByCustomerId(int customerId);
        Task<IEnumerable<OrderDisplayResponseDto>>? GetAllOrdersBySellerIdAsync(int sellerId);
        IEnumerable<OrderDisplayResponseDto>? GetAllOrdersBySellerId(int sellerId);
        Task<int> CreateOrderAndReturnIdAsync(CreateNewOrderRequestDto createNewOrderRequestDto);
        int CreateOrderAndReturnId(CreateNewOrderRequestDto createNewOrderRequestDto);
        Task DeleteOrderAsync(int id);
        void DeleteOrder(int id);
        Task<OrderDisplayResponseDto?> GetOrderByIdAsync(int orderId);
        OrderDisplayResponseDto? GetOrderById(int orderId);
    }
}
