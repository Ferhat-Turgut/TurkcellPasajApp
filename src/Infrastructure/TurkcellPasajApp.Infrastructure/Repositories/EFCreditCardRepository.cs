using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFCreditCardRepository:ICreditCardRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFCreditCardRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }
        public void Create(CreditCard entity)
        {
            _turkcellPasajAppDbContext.CreditCards.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(CreditCard entity)
        {
            await _turkcellPasajAppDbContext.CreditCards.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingCreditCard = _turkcellPasajAppDbContext.CreditCards.Find(id);
            _turkcellPasajAppDbContext.CreditCards.Remove(deletingCreditCard);
            _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingCreditCard = await _turkcellPasajAppDbContext.CreditCards.FindAsync(id);
            _turkcellPasajAppDbContext.CreditCards.Remove(deletingCreditCard);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public CreditCard? Get(int id)
        {
            var creditCard = _turkcellPasajAppDbContext.CreditCards.SingleOrDefault(c => c.Id == id);
            return creditCard;
        }

        public async Task<CreditCard?> GetAsync(int id)
        {
            var creditCard = await _turkcellPasajAppDbContext.CreditCards.SingleOrDefaultAsync(c => c.Id == id);
            return creditCard;
        }

        public IEnumerable<CreditCard> GetCreditCardsByCustomerId(int customerId)
        {
            var creditCards = _turkcellPasajAppDbContext.CreditCards.Where(c => c.CustomerId == customerId).ToList().AsEnumerable();
            return creditCards;
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCardsByCustomerIdAsync(int customerId)
        {
            var creditCards = await _turkcellPasajAppDbContext.CreditCards.Where(c => c.CustomerId == customerId).ToListAsync();
            return creditCards;
        }

        public void Update(CreditCard entity)
        {
            _turkcellPasajAppDbContext.CreditCards.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(CreditCard entity)
        {
            _turkcellPasajAppDbContext.CreditCards.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public bool BalanceCheck(int creditCardId, decimal totalAmount)
        {
            var creditCard = _turkcellPasajAppDbContext.CreditCards.Find(creditCardId);
            if (creditCard.AvaibleBalance>=totalAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> BalanceCheckAsync(int creditCardId, decimal totalAmount)
        {
            var creditCard =await _turkcellPasajAppDbContext.CreditCards.FindAsync(creditCardId);
            if (creditCard.AvaibleBalance >= totalAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
