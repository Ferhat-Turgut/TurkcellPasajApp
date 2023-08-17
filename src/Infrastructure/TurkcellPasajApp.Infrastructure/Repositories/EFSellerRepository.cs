using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFSellerRepository : ISellerRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFSellerRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }
        public void Create(Seller entity)
        {
            _turkcellPasajAppDbContext.Sellers.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Seller entity)
        {
            await _turkcellPasajAppDbContext.Sellers.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingSeller = _turkcellPasajAppDbContext.Sellers.Find(id);
            deletingSeller.IsActive = false;

            Update(deletingSeller);
        }

        public async Task DeleteAsync(int id)
        {
            var deletingSeller = await _turkcellPasajAppDbContext.Sellers.FindAsync(id);
            deletingSeller.IsActive = false;

            await UpdateAsync(deletingSeller);
        }

        public Seller? Get(int id)
        {
            var seller = _turkcellPasajAppDbContext.Sellers.SingleOrDefault(c => c.Id == id);
            return seller;
        }
        public async Task<Seller?> GetAsync(int id)
        {
            var seller = await _turkcellPasajAppDbContext.Sellers.SingleOrDefaultAsync(c => c.Id == id);
            return seller;
        }
        public IEnumerable<Seller> GetAllSellers()
        {
            var sellers = _turkcellPasajAppDbContext.Sellers.ToList().AsEnumerable();
            return sellers;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            var sellers = await _turkcellPasajAppDbContext.Sellers.ToListAsync();
            return sellers;
        }



        public void Update(Seller entity)
        {
            _turkcellPasajAppDbContext.Sellers.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Seller entity)
        {
            _turkcellPasajAppDbContext.Sellers.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Seller? GetSellerByUsername(string username)
        {
            var seller = _turkcellPasajAppDbContext.Sellers.FirstOrDefault(c => c.UserName == username);
            return seller;
        }

        public async Task<Seller>? GetSellerByUsernameAsync(string username)
        {
            var seller = await _turkcellPasajAppDbContext.Sellers.FirstOrDefaultAsync(c => c.UserName == username);
            return seller;
        }

        public Seller GetSellerForProfile(int sellerId)
        {
            var sellerProfile = _turkcellPasajAppDbContext.Sellers
                                .Include(s => s.Products) // Ürünleri dahil et
                                .ThenInclude(p => p.OrderDetails) // Ürünlerin sipariş detaylarını dahil et
                                .FirstOrDefault(s => s.Id == sellerId);

            return sellerProfile;


        }

        public async Task<Seller> GetSellerForProfileAsync(int sellerId)
        {
            var sellerProfile = await _turkcellPasajAppDbContext.Sellers
                           .Include(s => s.Products) // Ürünleri dahil et
                                                     // .ThenInclude(p => p.OrderDetails) // Ürünlerin sipariş detaylarını dahil et
                           .FirstOrDefaultAsync(s => s.Id == sellerId);
            return sellerProfile;
        }
    }
}
