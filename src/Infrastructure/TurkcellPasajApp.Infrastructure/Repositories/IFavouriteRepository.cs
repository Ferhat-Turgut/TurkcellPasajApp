using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IFavouriteRepository : IRepository<Favourite>
    {
        IEnumerable<Favourite> GetCustomerAllFavourites(int customerId);
        Task<IEnumerable<Favourite>> GetCustomerAllFavouritesAsync(int customerId);

        void ChangeFavouriteStatu(int favouriteId);
        Task ChangeFavouriteStatuAsync(int favouriteId);
    }
}
