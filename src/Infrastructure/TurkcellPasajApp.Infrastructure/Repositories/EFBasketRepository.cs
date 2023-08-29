using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFBasketRepository : IBasketRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFBasketRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void AddProductToBasketProduct(BasketProduct basketProduct)
        {
            _turkcellPasajAppDbContext.BasketProducts.Add(basketProduct);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task AddProductToBasketProductAsync(BasketProduct basketProduct)
        {
            await _turkcellPasajAppDbContext.BasketProducts.AddAsync(basketProduct);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Create(Basket entity)
        {
            _turkcellPasajAppDbContext.Baskets.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Basket entity)
        {
            await _turkcellPasajAppDbContext.Baskets.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var basket = _turkcellPasajAppDbContext.Baskets
                 .Include(b => b.BasketProducts) // İlişkili ürünleri de getir
                 .FirstOrDefault(b => b.Id == id);

            if (basket != null)
            {
                _turkcellPasajAppDbContext.Baskets.Remove(basket);

                // İlişkili ürünleri de sil
                foreach (var product in basket.BasketProducts)
                {
                    _turkcellPasajAppDbContext.BasketProducts.Remove(product);
                }

                _turkcellPasajAppDbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var basket = await _turkcellPasajAppDbContext.Baskets
                .Include(b => b.BasketProducts) // İlişkili ürünleri de getir
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basket != null)
            {
                _turkcellPasajAppDbContext.Baskets.Remove(basket);

                // İlişkili ürünleri de sil
                foreach (var product in basket.BasketProducts)
                {
                    _turkcellPasajAppDbContext.BasketProducts.Remove(product);
                }

                await _turkcellPasajAppDbContext.SaveChangesAsync();
            }
        }


        public Basket? Get(int id)
        {
            var basket = _turkcellPasajAppDbContext.Baskets
                .Include(b => b.BasketProducts) // BasketProduct tablosunu dahil ediyoruz
                .ThenInclude(bp => bp.Product) // Product tablosunu da dahil ediyoruz
                .SingleOrDefault(b => b.CustomerId == id);

            return basket;
        }


        public async Task<Basket>? GetAsync(int id)
        {
            var basket = await _turkcellPasajAppDbContext.Baskets
                .Include(b => b.BasketProducts) // BasketProduct tablosunu dahil ediyoruz
                .ThenInclude(bp => bp.Product) // Product tablosunu da dahil ediyoruz
                    .ThenInclude(p => p.Seller) // Seller bilgisini dahil ediyoruz
                .SingleOrDefaultAsync(b => b.CustomerId == id);

            return basket;
        }


        public BasketProduct? GetBasketProduct(int basketId, int productId)
        {
            var basketProduct = _turkcellPasajAppDbContext.BasketProducts
                .SingleOrDefault(bp => bp.BasketId == basketId && bp.ProductId == productId);
            return basketProduct;
        }

        public async Task<BasketProduct?> GetBasketProductAsync(int basketId, int productId)
        {
            var basketProduct = await _turkcellPasajAppDbContext.BasketProducts
                .SingleOrDefaultAsync(bp => bp.BasketId == basketId && bp.ProductId == productId);

            return basketProduct;
        }

        public int? GetCustomerBasketId(int customerId)
        {
            var customersBasket = _turkcellPasajAppDbContext.Baskets.SingleOrDefault(b => b.CustomerId == customerId);
            return customersBasket.Id;
        }

        public async Task<int>? GetCustomerBasketIdAsync(int customerId)
        {
            var customersBasket = await _turkcellPasajAppDbContext.Baskets.SingleOrDefaultAsync(b => b.CustomerId == customerId);
            return customersBasket.Id;
        }

        public bool IsCustomerHaveBasket(int customerId)
        {
            var isHaveBasket = _turkcellPasajAppDbContext.Baskets.Any(b => b.CustomerId == customerId);
            return isHaveBasket;
        }

        public async Task<bool> IsCustomerHaveBasketAsync(int customerId)
        {
            var isHaveBasket = await _turkcellPasajAppDbContext.Baskets.AnyAsync(b => b.CustomerId == customerId);
            return isHaveBasket;
        }

        public void RemoveProductToBasketProduct(BasketProduct basketProduct)
        {
            var product = _turkcellPasajAppDbContext.BasketProducts.SingleOrDefault(bp => bp.BasketId == basketProduct.BasketId && bp.ProductId == basketProduct.ProductId);
            _turkcellPasajAppDbContext.BasketProducts.Remove(product);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task RemoveProductToBasketProductAsync(BasketProduct basketProduct)
        {
            var product = await _turkcellPasajAppDbContext.BasketProducts.SingleOrDefaultAsync(bp => bp.BasketId == basketProduct.BasketId && bp.ProductId == basketProduct.ProductId);
            _turkcellPasajAppDbContext.BasketProducts.Remove(product);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public void Update(Basket entity)
        {
            _turkcellPasajAppDbContext.Baskets.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Basket entity)
        {
            _turkcellPasajAppDbContext.Baskets.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void UpdateBasketProduct(BasketProduct basketProduct)
        {
            _turkcellPasajAppDbContext.BasketProducts.Update(basketProduct);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateBasketProductAsync(BasketProduct basketProduct)
        {
            var existingBasketProduct = await _turkcellPasajAppDbContext.BasketProducts
        .SingleOrDefaultAsync(bp => bp.BasketId == basketProduct.BasketId && bp.ProductId == basketProduct.ProductId);

            if (existingBasketProduct != null)
            {
                existingBasketProduct.Quantity = basketProduct.Quantity;

                _turkcellPasajAppDbContext.BasketProducts.Update(existingBasketProduct);
                await _turkcellPasajAppDbContext.SaveChangesAsync();
            }
        }
    }
}
