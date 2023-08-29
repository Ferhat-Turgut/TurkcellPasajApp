using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface IBasketService
    {
        void AddProductToBasket(CreateNewBasketProductRequestDto createBasketProduct);
        Task AddProductToBasketAsync(CreateNewBasketProductRequestDto createBasketProduct);

        void RemoveProductToBasketProduct(BasketProduct basketProduct);
        Task RemoveProductToBasketProductAsync(BasketProduct basketProduct);

        int? GetCustomerBasketId(int customerId);
        Task<int>? GetCustomerBasketIdAsync(int customerId);
        Task<BasketProductsDisplayResponseDto>? GetBasketProductAsync(int basketId, int productId);
        BasketProductsDisplayResponseDto? GetBasketProduct(int basketId, int productId);

        bool IsCustomerHaveBasket(int customerId);
        Task<bool> IsCustomerHaveBasketAsync(int customerId);
        BasketDisplayResponseDto? GetBasket(int customerId);
        Task<BasketDisplayResponseDto>? GetBasketAsync(int customerId);

        Task CreateBasketAsync(CreateNewBasketRequestDto createNewBasket);
        void CreateBasket(CreateNewBasketRequestDto createNewBasket);
        Task DeleteBasketAsync(int id);
        void DeleteBasket(int id);
        Task UpdateBasketAsync(Basket basket);
        void UpdateBasket(Basket basket );
        Task UpdateBasketProductsAsync(UpdateBasketProductsRequestDto updateBasketProducts);
        void UpdateBasketProducts(UpdateBasketProductsRequestDto updateBasketProducts);
    }
}
