﻿using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}