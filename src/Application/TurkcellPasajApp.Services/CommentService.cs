using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public void CreateComment(CreateNewCommetRequestDto createNewCommetRequestDto)
        {
            var newComment = _mapper.Map<Comment>(createNewCommetRequestDto);
            _commentRepository.Create(newComment);
        }

        public async Task CreateCommentAsync(CreateNewCommetRequestDto createNewCommetRequestDto)
        {
            var newComment = _mapper.Map<Comment>(createNewCommetRequestDto);
            await _commentRepository.CreateAsync(newComment);
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(id);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public CommentDisplayResponseDto GetCommentById(int commentId)
        {
            var comment=_commentRepository.Get(commentId);
            return _mapper.Map<CommentDisplayResponseDto>(comment);
        }

        public async Task<CommentDisplayResponseDto> GetCommentByIdAsync(int commentId)
        {
            var comment =await _commentRepository.GetAsync(commentId);
            return _mapper.Map<CommentDisplayResponseDto>(comment);
        }

        public IEnumerable<CommentDisplayResponseDto>? GetCommentsByCustomerId(int customerId)
        {
            var customerComments = _commentRepository.GetCommentsByCustomerId(customerId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(customerComments);
        }

        public async Task<IEnumerable<CommentDisplayResponseDto>>? GetCommentsByCustomerIdAsync(int customerId)
        {
            var customerComments = await _commentRepository.GetCommentsByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(customerComments);
        }

        public IEnumerable<CommentDisplayResponseDto>? GetCommentsByProductId(int productId)
        {
            var productComments = _commentRepository.GetCommentsByProductId(productId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(productComments);
        }

        public async Task<IEnumerable<CommentDisplayResponseDto>>? GetCommentsByProductIdAsync(int productId)
        {
            var productComments =await _commentRepository.GetCommentsByProductIdAsync(productId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(productComments);
        }

        public IEnumerable<CommentDisplayResponseDto>? GetSellersByCustomerId(int sellerId)
        {
            var sellerComments=_commentRepository.GetCommentsBySellerId(sellerId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(sellerComments);
        }

        public async Task<IEnumerable<CommentDisplayResponseDto>>? GetSellersByCustomerIdAsync(int sellerId)
        {
            var sellerComments =await _commentRepository.GetCommentsBySellerIdAsync(sellerId);
            return _mapper.Map<IEnumerable<CommentDisplayResponseDto>>(sellerComments);
        }
    }
}
