using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFFavouriteRepository:IFavouriteRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFFavouriteRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void ChangeFavouriteStatu(int favouriteId)
        {
            var favourite = _turkcellPasajAppDbContext.Favourites.Find(favouriteId);
            if (favourite.IsFavourite == true)
            { 
                favourite.IsFavourite = false; 
            }
            else
            {
                favourite.IsFavourite = true;
            }
            _turkcellPasajAppDbContext.Favourites.Update(favourite);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task ChangeFavouriteStatuAsync(int favouriteId)
        {
            var favourite =await _turkcellPasajAppDbContext.Favourites.FindAsync(favouriteId);
            if (favourite.IsFavourite == true)
            {
                favourite.IsFavourite = false;
            }
            else
            {
                favourite.IsFavourite = true;
            }
             _turkcellPasajAppDbContext.Favourites.Update(favourite);
             await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Create(Favourite entity)
        {
            _turkcellPasajAppDbContext.Favourites.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Favourite entity)
        {
            await _turkcellPasajAppDbContext.Favourites.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingFavourite = _turkcellPasajAppDbContext.Favourites.Find(id);
            _turkcellPasajAppDbContext.Favourites.Remove(deletingFavourite);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingFavourite = await _turkcellPasajAppDbContext.Favourites.FindAsync(id);
            _turkcellPasajAppDbContext.Favourites.Remove(deletingFavourite);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Favourite? Get(int id)
        {
            var favourite = _turkcellPasajAppDbContext.Favourites.SingleOrDefault(f => f.Id == id);
            return favourite;
        }

        public async Task<Favourite?> GetAsync(int id)
        {
            var favourite = await _turkcellPasajAppDbContext.Favourites.SingleOrDefaultAsync(f => f.Id == id);
            return favourite;
        }

        public IEnumerable<Favourite> GetCustomerAllFavourites(int customerId)
        {
            var favourites = _turkcellPasajAppDbContext.Favourites.Where(f => f.CustomerId == customerId).ToList().AsEnumerable();
            return favourites;
        }

        public async Task<IEnumerable<Favourite>> GetCustomerAllFavouritesAsync(int customerId)
        {
            var favourites = await _turkcellPasajAppDbContext.Favourites.Where(f => f.CustomerId == customerId).ToListAsync();
            return favourites;
        }

        public void Update(Favourite entity)
        {
            _turkcellPasajAppDbContext.Favourites.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Favourite entity)
        {
            _turkcellPasajAppDbContext.Favourites.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
