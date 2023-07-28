using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
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
    }
}
