using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public int CreateOrderAndReturnId(CreateNewOrderRequestDto createNewOrderRequestDto)
        {
            var order=_mapper.Map<Order>(createNewOrderRequestDto);
            var orderId=_orderRepository.CreateOrderAndReturnId(order);
            return orderId;
        }

        public async Task<int> CreateOrderAndReturnIdAsync(CreateNewOrderRequestDto createNewOrderRequestDto)
        {
            var order = _mapper.Map<Order>(createNewOrderRequestDto);
            var orderId =await _orderRepository.CreateOrderAndReturnIdAsync(order);
            return orderId;
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public async Task DeleteOrderAsync(int id)
        {
           await _orderRepository.DeleteAsync(id);
        }

        public IEnumerable<Order>? GetAllOrdersByCustomerId(int customerId)
        {
            var customersOrders=_orderRepository.GetAllByCustomerId(customerId);
            return customersOrders;
        }

        public async Task<IEnumerable<Order>>? GetAllOrdersByCustomerIdAsync(int customerId)
        {
            var customersOrders =await _orderRepository.GetAllByCustomerIdAsync(customerId);
            return customersOrders;
        }

        public IEnumerable<OrderDisplayResponseDto>? GetAllOrdersBySellerId(int sellerId)
        {
            var sellersOrders = _orderRepository.GetAllBySellerId(sellerId);
            return _mapper.Map<IEnumerable<OrderDisplayResponseDto>>(sellerId);
        }

        public async Task<IEnumerable<OrderDisplayResponseDto>>? GetAllOrdersBySellerIdAsync(int sellerId)
        {
            var sellersOrders =await _orderRepository.GetAllBySellerIdAsync(sellerId);
            return _mapper.Map<IEnumerable<OrderDisplayResponseDto>>(sellerId);
        }

        public OrderDisplayResponseDto? GetOrderById(int orderId)
        {
            var order=_orderRepository.Get(orderId);
            return _mapper.Map<OrderDisplayResponseDto>(order);
        }

        public async Task<OrderDisplayResponseDto?> GetOrderByIdAsync(int orderId)
        {
            var order =await _orderRepository.GetAsync(orderId);
            return _mapper.Map<OrderDisplayResponseDto>(order);
        }
    }
}
