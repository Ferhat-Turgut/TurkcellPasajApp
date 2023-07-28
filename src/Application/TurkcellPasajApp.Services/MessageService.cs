using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public void CreateNewMessage(CreateNewMessageRequestDto createNewMessageRequestDto)
        {
            var message = _mapper.Map<Message>(createNewMessageRequestDto);
            _messageRepository.Create(message);
        }

        public async Task CreateNewMessageAsync(CreateNewMessageRequestDto createNewMessageRequestDto)
        {
            var message =_mapper.Map<Message>(createNewMessageRequestDto);
            await _messageRepository.CreateAsync(message);
        }

        public void DeleteMessage(int messageId)
        {
            _messageRepository.Delete(messageId);
        }

        public async Task DeleteMessageAsync(int messageId)
        {
            await _messageRepository.DeleteAsync(messageId);
        }

        public MessageDisplayResponseDto? GetMessageById(int messageId)
        {
            var message=_messageRepository.Get(messageId);
            return _mapper.Map<MessageDisplayResponseDto>(message);
        }

        public async Task<MessageDisplayResponseDto>? GetMessageByIdAsync(int messageId)
        {
            var message =await _messageRepository.GetAsync(messageId);
            return _mapper.Map<MessageDisplayResponseDto>(message);
        }

        public IEnumerable<MessageDisplayResponseDto>? GetReceivedMessagesByUserMail(string userEmail)
        {
            var receviedMessages = _messageRepository.GetAllReceivedMessagesByUserEmail(userEmail);
            return _mapper.Map<IEnumerable<MessageDisplayResponseDto>>(receviedMessages);
        }

        public async Task<IEnumerable<MessageDisplayResponseDto>>? GetReceivedMessagesByUserMailAsync(string userEmail)
        {
            var receviedMessages=await _messageRepository.GetAllReceivedMessagesByUserEmailAsync(userEmail);
            return _mapper.Map<IEnumerable<MessageDisplayResponseDto>>(receviedMessages);
        }

        public IEnumerable<MessageDisplayResponseDto>? GetSentMessagesByUserMail(string userEmail)
        {
            var sentMessages = _messageRepository.GetAllSentMessagesByUserEmail(userEmail);
            return _mapper.Map<IEnumerable<MessageDisplayResponseDto>>(sentMessages);
        }

        public async Task<IEnumerable<MessageDisplayResponseDto>>? GetSentMessagesByUserMailAsync(string userEmail)
        {
            var sentMessages =await _messageRepository.GetAllSentMessagesByUserEmailAsync(userEmail);
            return _mapper.Map<IEnumerable<MessageDisplayResponseDto>>(sentMessages);
        }
    }
}
