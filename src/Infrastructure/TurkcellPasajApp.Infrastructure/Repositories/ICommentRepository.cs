using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByUserId(int userId,string Role);
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId,string Role);

        IEnumerable<Comment> GetCommentsByProductId(int productId);
        Task<IEnumerable<Comment>> GetCommentsByProductIdAsync(int productId);
    }
}
