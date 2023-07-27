using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFCommentRepository:ICommentRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFCommentRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }
        public void Create(Comment entity)
        {
            _turkcellPasajAppDbContext.Comments.Add(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task CreateAsync(Comment entity)
        {
            await _turkcellPasajAppDbContext.Comments.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingComment = _turkcellPasajAppDbContext.Comments.Find(id);
            _turkcellPasajAppDbContext.Comments.Remove(deletingComment);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingComment = await _turkcellPasajAppDbContext.Comments.FindAsync(id);
            _turkcellPasajAppDbContext.Comments.Remove(deletingComment);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Comment? Get(int id)
        {
            var comment = _turkcellPasajAppDbContext.Comments.SingleOrDefault(c => c.Id == id);
            return comment;
        }

        public async Task<Comment?> GetAsync(int id)
        {
            var comment = await _turkcellPasajAppDbContext.Comments.SingleOrDefaultAsync(c => c.Id == id);
            return comment;
        }

        public IEnumerable<Comment> GetCommentsByCustomerId(int userId, string Role)
        {
            var customerComments = _turkcellPasajAppDbContext.Comments.Where(c => c.UserId == userId && c.Role==Role).ToList().AsEnumerable();
            return customerComments;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByCustomerIdAsync(int userId, string Role)
        {
            var customerComments = await _turkcellPasajAppDbContext.Comments.Where(c => c.UserId == userId && c.Role == Role).ToListAsync();
            return customerComments;
        }

        public IEnumerable<Comment> GetCommentsByProductId(int productId)
        {
            var productComments = _turkcellPasajAppDbContext.Comments.Where(c => c.CommentProductId == productId).ToList().AsEnumerable();
            return productComments;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByProductIdAsync(int productId)
        {
            var productComments = await _turkcellPasajAppDbContext.Comments.Where(c => c.CommentProductId == productId).ToListAsync();
            return productComments;
        }

        public void Update(Comment entity)
        {
            _turkcellPasajAppDbContext.Comments.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Comment entity)
        {
            _turkcellPasajAppDbContext.Comments.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
