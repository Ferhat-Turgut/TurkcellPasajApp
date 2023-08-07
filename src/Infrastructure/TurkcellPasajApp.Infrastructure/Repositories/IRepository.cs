using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        void Create(T entity);
        Task CreateAsync(T entity);

        void Delete(int id);
        Task DeleteAsync(int id);

        void Update(T entity);
        Task UpdateAsync(T entity);

        T? Get(int id);
        Task<T>? GetAsync(int id);
    }
}
