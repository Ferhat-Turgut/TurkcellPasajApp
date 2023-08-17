using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ISellerRepository:IRepository<Seller>
    {
        IEnumerable<Seller> GetAllSellers();
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Seller? GetSellerByUsername(string username);
        Task<Seller>? GetSellerByUsernameAsync(string username);
        Seller GetSellerForProfile(int sellerId);
        Task<Seller> GetSellerForProfileAsync(int sellerId);

    }
}
