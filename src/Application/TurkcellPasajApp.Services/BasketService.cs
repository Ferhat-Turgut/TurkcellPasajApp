using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public void AddProductToBasket(BasketProduct basketProduct)
        {
            _basketRepository.AddProductToBasketProduct(basketProduct);
        }

        public async Task AddProductToBasketAsync(BasketProduct basketProduct)
        {
            await _basketRepository.AddProductToBasketProductAsync(basketProduct);
        }

        public void CreateBasket(Basket basket)
        {
            _basketRepository.Create(basket);
        }

        public async Task CreateBasketAsync(Basket basket)
        {
            await _basketRepository.CreateAsync(basket);
        }

        public void DeleteBasket(int id)
        {
            _basketRepository.Delete(id );
        }

        public async Task DeleteBasketAsync(int id)
        {
             await _basketRepository.DeleteAsync(id);
        }

        public Basket? GetBasket(int customerId)
        {
            var basket=_basketRepository.Get(customerId);
            return basket;
        }

        public async Task<Basket>? GetBasketAsync(int customerId)
        {
            var basket =await _basketRepository.GetAsync(customerId);
            return basket;
        }

        public int? GetCustomerBasketId(int customerId)
        {
            var customersBasketId=_basketRepository.GetCustomerBasketId(customerId);
            return customersBasketId;
        }

        public async Task<int>? GetCustomerBasketIdAsync(int customerId)
        {
            var customersBasketId =await _basketRepository.GetCustomerBasketIdAsync(customerId);
            return customersBasketId;
        }

        public bool IsCustomerHaveBasket(int customerId)
        {
            var isHaveBasket = _basketRepository.IsCustomerHaveBasket(customerId);
            return isHaveBasket;
        }

        public async Task<bool> IsCustomerHaveBasketAsync(int customerId)
        {
            var isHaveBasket =await _basketRepository.IsCustomerHaveBasketAsync(customerId);
            return isHaveBasket;
        }

        public void RemoveProductToBasketProduct(BasketProduct basketProduct)
        {
            _basketRepository.RemoveProductToBasketProduct(basketProduct);
        }

        public async Task RemoveProductToBasketProductAsync(BasketProduct basketProduct)
        {
            await _basketRepository.RemoveProductToBasketProductAsync(basketProduct);
        }

        public void UpdateBasket(Basket basket)
        {
            _basketRepository.Update(basket);
        }

        public async Task UpdateBasketAsync(Basket basket)
        {
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
