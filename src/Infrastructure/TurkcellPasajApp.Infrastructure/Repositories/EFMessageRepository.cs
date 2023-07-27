using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Data;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public class EFMessageRepository : IMessageRepository
    {
        private readonly TurkcellPasajAppDbContext _turkcellPasajAppDbContext;

        public EFMessageRepository(TurkcellPasajAppDbContext turkcellPasajAppDbContext)
        {
            _turkcellPasajAppDbContext = turkcellPasajAppDbContext;
        }

        public void Create(Message entity)
        {
            _turkcellPasajAppDbContext.Messages.AddAsync(entity);
            _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Message entity)
        {
            await _turkcellPasajAppDbContext.Messages.AddAsync(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingMessage = _turkcellPasajAppDbContext.Messages.Find(id);
            _turkcellPasajAppDbContext.Messages.Remove(deletingMessage);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingMessage = await _turkcellPasajAppDbContext.Messages.FindAsync(id);
            _turkcellPasajAppDbContext.Messages.Remove(deletingMessage);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }

        public Message? Get(int id)
        {
            var message = _turkcellPasajAppDbContext.Messages.SingleOrDefault(m => m.Id == id);
            return message;
        }
        public async Task<Message?> GetAsync(int id)
        {
            var message = await _turkcellPasajAppDbContext.Messages.SingleOrDefaultAsync(m => m.Id == id);
            return message;
        }
        public IEnumerable<Message> GetAllMessages()
        {
            var messages = _turkcellPasajAppDbContext.Messages.ToList().AsEnumerable();
            return messages;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            var messages = await _turkcellPasajAppDbContext.Messages.ToListAsync();
            return messages;
        }

        public IEnumerable<Message> GetAllReceivedMessagesByUserEmail(string userEmail)
        {
            var receviedMessages = _turkcellPasajAppDbContext.Messages.Where(m => m.ReceiverMail == userEmail).ToList().AsEnumerable();
            return receviedMessages;
        }

        public async Task<IEnumerable<Message>> GetAllReceivedMessagesByUserEmailAsync(string userEmail)
        {
            var receviedMessages = await _turkcellPasajAppDbContext.Messages.Where(m => m.ReceiverMail == userEmail).ToListAsync();
            return receviedMessages;
        }

        public IEnumerable<Message> GetAllSentMessagesByUserEmail(string userEmail)
        {
            var sentMessages = _turkcellPasajAppDbContext.Messages.Where(m => m.SenderMail == userEmail).ToList().AsEnumerable();
            return sentMessages;
        }

        public async Task<IEnumerable<Message>> GetAllSentMessagesByUserEmailAsync(string userEmail)
        {
            var sentMessages = await _turkcellPasajAppDbContext.Messages.Where(m => m.SenderMail == userEmail).ToListAsync();
            return sentMessages;
        }
        public void Update(Message entity)
        {
            _turkcellPasajAppDbContext.Messages.Update(entity);
            _turkcellPasajAppDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Message entity)
        {
            _turkcellPasajAppDbContext.Messages.Update(entity);
            await _turkcellPasajAppDbContext.SaveChangesAsync();
        }
    }
}
