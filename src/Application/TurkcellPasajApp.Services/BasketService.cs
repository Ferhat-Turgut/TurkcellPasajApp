using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper= mapper;
        }

        public void AddProductToBasket(CreateNewBasketProductRequestDto createBasketProduct)
        {
            var addBasketProduct = _mapper.Map<BasketProduct>(createBasketProduct);
            _basketRepository.AddProductToBasketProduct(addBasketProduct);
        }

        public async Task AddProductToBasketAsync(CreateNewBasketProductRequestDto createBasketProduct)
        {
            var addBasketProduct = _mapper.Map<BasketProduct>(createBasketProduct);
            await _basketRepository.AddProductToBasketProductAsync(addBasketProduct);
        }

        public void CreateBasket(CreateNewBasketRequestDto createNewBasket)
        {
            var newBasket=_mapper.Map<Basket>(createNewBasket);
            _basketRepository.Create(newBasket);
        }

        public async Task CreateBasketAsync(CreateNewBasketRequestDto createNewBasket)
        {
            var newBasket = _mapper.Map<Basket>(createNewBasket);
            await _basketRepository.CreateAsync(newBasket);
        }

        public void DeleteBasket(int id)
        {
            _basketRepository.Delete(id);
        }

        public async Task DeleteBasketAsync(int id)
        {
            await _basketRepository.DeleteAsync(id);
        }

        public BasketDisplayResponseDto? GetBasket(int customerId)
        {
            var basket = _basketRepository.Get(customerId);
            return _mapper.Map<BasketDisplayResponseDto>(basket);
        }

        public async Task<BasketDisplayResponseDto>? GetBasketAsync(int customerId)
        {
            var basket = await _basketRepository.GetAsync(customerId);
            return _mapper.Map<BasketDisplayResponseDto>(basket);
        }

        public BasketProductsDisplayResponseDto? GetBasketProduct(int basketId, int productId)
        {
            var basketProduct = _basketRepository.GetBasketProduct(basketId, productId);
            return _mapper.Map<BasketProductsDisplayResponseDto>(basketProduct);
        }

        public async Task<BasketProductsDisplayResponseDto>? GetBasketProductAsync(int basketId, int productId)
        {
            var basketProduct =await _basketRepository.GetBasketProductAsync(basketId, productId);
            return _mapper.Map<BasketProductsDisplayResponseDto>(basketProduct);
        }

        public int? GetCustomerBasketId(int customerId)
        {
            var customersBasketId = _basketRepository.GetCustomerBasketId(customerId);
            return customersBasketId;
        }

        public async Task<int>? GetCustomerBasketIdAsync(int customerId)
        {
            var customersBasketId = await _basketRepository.GetCustomerBasketIdAsync(customerId);
            return customersBasketId;
        }

        public bool IsCustomerHaveBasket(int customerId)
        {
            var isHaveBasket = _basketRepository.IsCustomerHaveBasket(customerId);
            return isHaveBasket;
        }

        public async Task<bool> IsCustomerHaveBasketAsync(int customerId)
        {
            var isHaveBasket = await _basketRepository.IsCustomerHaveBasketAsync(customerId);
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

        public void UpdateBasketProducts(UpdateBasketProductsRequestDto updateBasketProducts)
        {
            var basketProduct = _mapper.Map<BasketProduct>(updateBasketProducts);
            _basketRepository.UpdateBasketProduct(basketProduct);
        }

        public async Task UpdateBasketProductsAsync(UpdateBasketProductsRequestDto updateBasketProducts)
        {
            var basketProduct = _mapper.Map<BasketProduct>(updateBasketProducts);
            await _basketRepository.UpdateBasketProductAsync(basketProduct);
        }
    }
}
