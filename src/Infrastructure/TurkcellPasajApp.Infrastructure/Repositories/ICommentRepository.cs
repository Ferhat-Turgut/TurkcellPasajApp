using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByCustomerId(int customerId);
        Task<IEnumerable<Comment>> GetCommentsByCustomerIdAsync(int customerId);
        IEnumerable<Comment> GetCommentsBySellerId(int sellerId);
        Task<IEnumerable<Comment>> GetCommentsBySellerIdAsync(int sellerId);

        IEnumerable<Comment> GetCommentsByProductId(int productId);
        Task<IEnumerable<Comment>> GetCommentsByProductIdAsync(int productId);
    }
}
