﻿using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFOrderRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void Create(Order entity)
        {
            _turkcellPasajAppDbContext.Orders.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Order entity)
        {
            await _turkcellPasajAppDbContext.Orders.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingOrder = _turkcellPasajAppDbContext.Orders.Find(id);
            _turkcellPasajAppDbContext.Orders.Remove(deletingOrder);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingOrder = await _turkcellPasajAppDbContext.Orders.FindAsync(id);
            _turkcellPasajAppDbContext.Orders.Remove(deletingOrder);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Order? Get(int id)
        {
            var order = _turkcellPasajAppDbContext.Orders.SingleOrDefault(o => o.Id == id);
            return order;
        }
        public async Task<Order?> GetAsync(int id)
        {
            var order = await _turkcellPasajAppDbContext.Orders.SingleOrDefaultAsync(m => m.Id == id);
            return order;
        }

        public IEnumerable<Order>? GetAll()
        {
            var orders = _turkcellPasajAppDbContext.Orders.ToList().AsEnumerable();
            return orders;
        }

        public async Task<IEnumerable<Order>>? GetAllAsync()
        {
            var orders = await _turkcellPasajAppDbContext.Orders.ToListAsync();
            return orders;
        }

        public IEnumerable<Order>? GetAllByCustomerId(int customerId)
        {
            var customerOrders = _turkcellPasajAppDbContext.Orders.Where(o => o.CustomerId == customerId).ToList().AsEnumerable();
            return customerOrders;
        }

        public async Task<IEnumerable<Order>>? GetAllByCustomerIdAsync(int customerId)
        {
            var customerOrders = await _turkcellPasajAppDbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
            return customerOrders;
        }

        public IEnumerable<Order>? GetAllBySellerId(int sellerId)
        {
            var sellerOrders = _turkcellPasajAppDbContext.Orders.Where(o => o.SellerId == sellerId).ToList().AsEnumerable();
            return sellerOrders;
        }

        public async Task<IEnumerable<Order>>? GetAllBySellerIdAsync(int sellerId)
        {
            var sellerOrders = await _turkcellPasajAppDbContext.Orders.Where(o => o.SellerId == sellerId).ToListAsync();
            return sellerOrders;
        }



        public void Update(Order entity)
        {
            _turkcellPasajAppDbContext.Orders.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Order entity)
        {
            _turkcellPasajAppDbContext.Orders.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
