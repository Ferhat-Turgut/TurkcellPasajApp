using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetAllSentMessagesByUserEmail(string userEmail);
        Task<IEnumerable<Message>> GetAllSentMessagesByUserEmailAsync(string userEmail);
        IEnumerable<Message> GetAllReceivedMessagesByUserEmail(string userEmail);
        Task<IEnumerable<Message>> GetAllReceivedMessagesByUserEmailAsync(string userEmail);
        IEnumerable<Message> GetAllMessages();
        Task<IEnumerable<Message>> GetAllMessagesAsync();
    }
}
