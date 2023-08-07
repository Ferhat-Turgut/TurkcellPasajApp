using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDisplayResponseDto>>? GetAllOrdersByCustomerIdAsync(int customerId);
        IEnumerable<OrderDisplayResponseDto>? GetAllOrdersByCustomerId(int customerId);
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
