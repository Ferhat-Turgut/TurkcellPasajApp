using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IBasketRepository:IRepository<Basket>
    {
        void AddProductToBasketProduct(BasketProduct basketProduct);
        Task AddProductToBasketProductAsync(BasketProduct basketProduct);
        void RemoveProductToBasketProduct(BasketProduct basketProduct);
        Task RemoveProductToBasketProductAsync(BasketProduct basketProduct);

        int?  GetCustomerBasketId(int customerId);
        Task<int>? GetCustomerBasketIdAsync(int customerId);

        bool IsCustomerHaveBasket(int customerId);
        Task<bool> IsCustomerHaveBasketAsync(int customerId);
        

    }
}
