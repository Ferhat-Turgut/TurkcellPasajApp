using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        IEnumerable<CreditCard> GetCreditCardsByCustomerId(int customerId);
        Task<IEnumerable<CreditCard>> GetCreditCardsByCustomerIdAsync(int customerId);

        bool BalanceCheck(int creditCardId,decimal totalAmount);
        Task<bool> BalanceCheckAsync(int creditCardId, decimal totalAmount);
    }
}
