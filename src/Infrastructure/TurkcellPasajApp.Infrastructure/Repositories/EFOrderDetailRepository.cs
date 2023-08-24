using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFOrderDetailRepository: IOrderDetailRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFOrderDetailRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void Create(OrderDetail entity)
        {
            _turkcellPasajAppDbContext.OrderDetails.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(OrderDetail entity)
        {
            await _turkcellPasajAppDbContext.OrderDetails.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingOrderDetail = _turkcellPasajAppDbContext.OrderDetails.Find(id);
            _turkcellPasajAppDbContext.OrderDetails.Remove(deletingOrderDetail);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingOrderDetail = await _turkcellPasajAppDbContext.OrderDetails.FindAsync(id);
            _turkcellPasajAppDbContext.OrderDetails.Remove(deletingOrderDetail);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public OrderDetail? Get(int id)
        {
            var orderDetail = _turkcellPasajAppDbContext.OrderDetails.SingleOrDefault(o => o.Id == id);
            return orderDetail;
        }

        public IEnumerable<OrderDetail> GetAllByOrderId(int orderId)
        {
            var orderDetails = _turkcellPasajAppDbContext.OrderDetails
                                .Where(od => od.OrderId == orderId)
                                .Include(od => od.OrderDetailsProduct) 
                                .ToList();

            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllByOrderIdAsync(int orderId)
        {
            var orderDetails =await _turkcellPasajAppDbContext.OrderDetails
                               .Where(od => od.OrderId == orderId)
                               .Include(od => od.OrderDetailsProduct)
                               .ToListAsync();

            return orderDetails;
        }

        //public IEnumerable<OrderDetail> GetAllBySellerId(int sellerId)
        //{
        //    var orderDetails = _turkcellPasajAppDbContext.OrderDetails.Where(od=>od.);
        //}

        //public Task<IEnumerable<OrderDetail>> GetAllBySellerIdAsync(int sellerId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<OrderDetail?> GetAsync(int id)
        {
            var orderDetail = await _turkcellPasajAppDbContext.OrderDetails.SingleOrDefaultAsync(o => o.Id == id);
            return orderDetail;
        }

        public void Update(OrderDetail entity)
        {
            _turkcellPasajAppDbContext.OrderDetails.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            _turkcellPasajAppDbContext.OrderDetails.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
