using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public void CreateNewOrderDetail(CreateNewOrderDetailRequestDto createNewOrderDetailRequest)
        {
            var orderDetail=_mapper.Map<OrderDetail>(createNewOrderDetailRequest);
            _orderDetailRepository.Create(orderDetail);
        }

        public async Task CreateNewOrderDetailAsync(CreateNewOrderDetailRequestDto createNewOrderDetailRequest)
        {
            var orderDetail = _mapper.Map<OrderDetail>(createNewOrderDetailRequest);
            await _orderDetailRepository.CreateAsync(orderDetail);
        }

        public OrderDetail? GetOrderDetailById(int orderDetailId)
        {
            var orderDetail = _orderDetailRepository.Get(orderDetailId);
            return orderDetail;
        }

        public async Task<OrderDetail>? GetOrderDetailByIdAsync(int orderDetailId)
        {
            var orderDetail =await _orderDetailRepository.GetAsync(orderDetailId);
            return orderDetail;
        }

        public IEnumerable<OrderDetail>? GetOrderDetailByOrderId(int orderId)
        {
            var orderDetails=_orderDetailRepository.GetAllByOrderId(orderId);
            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetail>>? GetOrderDetailByOrderIdAsync(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetAllByOrderIdAsync(orderId);
            return orderDetails;
        }
    }
}
