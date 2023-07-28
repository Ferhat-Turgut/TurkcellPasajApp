using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDisplayResponseDto>>? GetCommentsByCustomerIdAsync(int customerId);
        IEnumerable<CommentDisplayResponseDto>? GetCommentsByCustomerId(int customerId);
        Task<IEnumerable<CommentDisplayResponseDto>>? GetCommentsByProductIdAsync(int productId);
        IEnumerable<CommentDisplayResponseDto>? GetCommentsByProductId(int productId);
        Task CreateCommentAsync(CreateNewCommetRequestDto createNewCommetRequestDto);
        void CreateComment(CreateNewCommetRequestDto createNewCommetRequestDto);
        Task DeleteCommentAsync(int id);
        void DeleteComment(int id);
        Task<CommentDisplayResponseDto> GetCommentByIdAsync(int commentId);
        CommentDisplayResponseDto GetCommentById(int commentId);
    }
}
