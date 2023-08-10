using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services
{
    public interface IBasketService
    {
        void AddProductToBasket(BasketProduct basketProduct);
        Task AddProductToBasketAsync(BasketProduct basketProduct);

        void RemoveProductToBasketProduct(BasketProduct basketProduct);
        Task RemoveProductToBasketProductAsync(BasketProduct basketProduct);

        int? GetCustomerBasketId(int customerId);
        Task<int>? GetCustomerBasketIdAsync(int customerId);

        bool IsCustomerHaveBasket(int customerId);
        Task<bool> IsCustomerHaveBasketAsync(int customerId);
        Basket? GetBasket(int customerId);
        Task<Basket>? GetBasketAsync(int customerId);

        Task CreateBasketAsync(Basket basket);
        void CreateBasket(Basket basket);
        Task DeleteBasketAsync(int id);
        void DeleteBasket(int id);
        Task UpdateBasketAsync(Basket basket);
        void UpdateBasket(Basket basket );
    }
}
