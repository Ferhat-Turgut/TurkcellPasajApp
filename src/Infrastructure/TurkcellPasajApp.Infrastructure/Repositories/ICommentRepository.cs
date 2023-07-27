using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByCustomerId(int userId,string Role);
        Task<IEnumerable<Comment>> GetCommentsByCustomerIdAsync(int userId,string Role);

        IEnumerable<Comment> GetCommentsByProductId(int productId);
        Task<IEnumerable<Comment>> GetCommentsByProductIdAsync(int productId);
    }
}
