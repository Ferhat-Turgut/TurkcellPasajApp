using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFCustomerRepository:ICustomerRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFCustomerRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }
        public void Create(Customer entity)
        {
            _turkcellPasajAppDbContext.Customers.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Customer entity)
        {
            await _turkcellPasajAppDbContext.Customers.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingCustomer = _turkcellPasajAppDbContext.Customers.Find(id);
            deletingCustomer.IsActive = false;

            Update(deletingCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            var deletingCustomer = await _turkcellPasajAppDbContext.Customers.FindAsync(id);
            deletingCustomer.IsActive = false;

            await UpdateAsync(deletingCustomer);
        }

        public Customer? Get(int id)
        {
            var customer = _turkcellPasajAppDbContext.Customers
                        .Include(c => c.CreditCards) 
                        .SingleOrDefault(c => c.Id == id);

            return customer;
        }
        public async Task<Customer?> GetAsync(int id)
        {
            var customer =await _turkcellPasajAppDbContext.Customers
                       .Include(c => c.CreditCards)
                       .SingleOrDefaultAsync(c => c.Id == id);

            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _turkcellPasajAppDbContext.Customers.ToList().AsEnumerable();
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _turkcellPasajAppDbContext.Customers.ToListAsync();
            return customers;
        }


        public void Update(Customer entity)
        {
            _turkcellPasajAppDbContext.Customers.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Customer entity)
        {
            _turkcellPasajAppDbContext.Customers.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Customer? GetCustomerByUsername(string username)
        {
            var customer=_turkcellPasajAppDbContext.Customers.FirstOrDefault(c=>c.UserName==username);
            return customer;
        }

        public async Task<Customer>? GetCustomerByUsernameAsync(string username)
        {
            var customer =await _turkcellPasajAppDbContext.Customers.FirstOrDefaultAsync(c => c.UserName == username);
            return customer;
        }

       
    }
}
