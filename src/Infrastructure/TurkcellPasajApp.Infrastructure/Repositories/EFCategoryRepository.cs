using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFCategoryRepository:ICategoryRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFCategoryRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }
        public void Create(Category entity)
        {
            _turkcellPasajAppDbContext.Categories.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Category entity)
        {
            await _turkcellPasajAppDbContext.Categories.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingCategory = _turkcellPasajAppDbContext.Categories.Find(id);
            _turkcellPasajAppDbContext.Categories.Remove(deletingCategory);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingCategory = await _turkcellPasajAppDbContext.Categories.FindAsync(id);
            _turkcellPasajAppDbContext.Categories.Remove(deletingCategory);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Category? Get(int id)
        {
            var category = _turkcellPasajAppDbContext.Categories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        public async Task<Category?> GetAsync(int id)
        {
            var category = await _turkcellPasajAppDbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }
        public IEnumerable<Category> GetAll()
        {
            var categories = _turkcellPasajAppDbContext.Categories.ToList().AsEnumerable();
            return categories;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _turkcellPasajAppDbContext.Categories.ToListAsync();
            return categories;
        }
        public void Update(Category entity)
        {
            _turkcellPasajAppDbContext.Categories.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Category entity)
        {
            _turkcellPasajAppDbContext.Categories.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
