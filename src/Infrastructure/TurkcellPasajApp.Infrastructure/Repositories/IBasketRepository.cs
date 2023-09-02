using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IBasketRepository:IRepository<Basket>
    {
        void AddProductToBasketProduct(BasketProduct basketProduct);
        Task AddProductToBasketProductAsync(BasketProduct basketProduct);
        void RemoveProductToBasketProduct(BasketProduct basketProduct);
        Task RemoveProductToBasketProductAsync(BasketProduct basketProduct);
        Task<BasketProduct>? GetBasketProductAsync(int basketId, int productId);
        BasketProduct? GetBasketProduct(int basketId, int productId);

        void UpdateBasketProduct(BasketProduct updateBasketProducts);
        Task UpdateBasketProductAsync(BasketProduct updateBasketProducts);
        int?  GetCustomerBasketId(int customerId);
        Task<int>? GetCustomerBasketIdAsync(int customerId);

        bool IsCustomerHaveBasket(int customerId);
        Task<bool> IsCustomerHaveBasketAsync(int customerId);

        void UpdateBasketAmount(int basketId);
        Task UpdateBasketAmountAsync(int basketId);


    }
}
