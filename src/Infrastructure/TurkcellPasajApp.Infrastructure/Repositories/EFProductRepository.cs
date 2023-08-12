using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository

    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFProductRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void Create(Product entity)
        {
            _turkcellPasajAppDbContext.Products.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Product entity)
        {
            await _turkcellPasajAppDbContext.Products.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingProduct = _turkcellPasajAppDbContext.Products.Find(id);
            _turkcellPasajAppDbContext.Products.Remove(deletingProduct);
            _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingProduct = await _turkcellPasajAppDbContext.Products.FindAsync(id);
            _turkcellPasajAppDbContext.Products.Remove(deletingProduct);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Product? Get(int id)
        {
            var product = _turkcellPasajAppDbContext.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public async Task<Product?> GetAsync(int id)
        {
            var product = await _turkcellPasajAppDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = _turkcellPasajAppDbContext.Products.ToList().AsEnumerable();
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _turkcellPasajAppDbContext.Products.ToListAsync();
            return products;
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            var productsByCategory =_turkcellPasajAppDbContext.Products
                                    .Where(p => p.CategoryId == categoryId)
                                    .Include(p => p.Category) // Kategori tablosunu dahil ediyoruz
                                    .Include(p => p.Seller)   // Satıcı tablosunu dahil ediyoruz
                                    .ToList();

            return productsByCategory;

        }

        public async Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId)
        {
            var productsByCategory =await _turkcellPasajAppDbContext.Products
                                   .Where(p => p.CategoryId == categoryId)
                                   .Include(p => p.Category) // Kategori tablosunu dahil ediyoruz
                                   .Include(p => p.Seller)   // Satıcı tablosunu dahil ediyoruz
                                   .ToListAsync();

            return productsByCategory;
        }

     

        public bool IsInStock(int productId)
        {
            return _turkcellPasajAppDbContext.Products.Any(p => p.Id == productId);
        }

        public async Task<bool> IsInStockAsync(int productId)
        {
            return await _turkcellPasajAppDbContext.Products.AnyAsync(p => p.Id == productId);
        }

        public void Update(Product entity)
        {
            _turkcellPasajAppDbContext.Products.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Product entity)
        {
            _turkcellPasajAppDbContext.Products.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAllBySellerId(int sellerId)
        {
            var productsBySeller = _turkcellPasajAppDbContext.Products.Where(p => p.SellerId == sellerId).ToList();
            return productsBySeller;
        }

        public async Task<IEnumerable<Product>> GetAllBySellerIdAsync(int sellerId)
        {
            var productsBySeller = await _turkcellPasajAppDbContext.Products.Where(p => p.SellerId == sellerId).ToListAsync();
            return productsBySeller;
        }

        public IEnumerable<Product>? GetProductsForSearch(string searchText)
        {
            var products = _turkcellPasajAppDbContext.Products.Where(p=>p.Name.Contains(searchText)).ToList().AsEnumerable();
            return products;
        }

        public async Task<IEnumerable<Product>>? GetProductsForSearchAsync(string searchText)
        {
            var products =await _turkcellPasajAppDbContext.Products.Where(p => p.Name.Contains(searchText)).ToListAsync();
            return products;
        }
    }
}
