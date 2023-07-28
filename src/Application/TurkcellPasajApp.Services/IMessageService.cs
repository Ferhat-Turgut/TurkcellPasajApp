using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDisplayResponseDto>>? GetSentMessagesByUserMailAsync(string userEmail);
        IEnumerable<MessageDisplayResponseDto>? GetSentMessagesByUserMail(string userEmail);
        Task<IEnumerable<MessageDisplayResponseDto>>? GetReceivedMessagesByUserMailAsync(string userEmail);
        IEnumerable<MessageDisplayResponseDto>? GetReceivedMessagesByUserMail(string userEmail);
        Task CreateNewMessageAsync(CreateNewMessageRequestDto createNewMessageRequestDto);
        void CreateNewMessage(CreateNewMessageRequestDto createNewMessageRequestDto);
        Task DeleteMessageAsync(int messageId);
        void DeleteMessage(int messageId);
        Task<MessageDisplayResponseDto>? GetMessageByIdAsync(int messageId);
        MessageDisplayResponseDto? GetMessageById(int messageId);
    }
}
