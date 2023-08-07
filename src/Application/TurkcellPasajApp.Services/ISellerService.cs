using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface ISellerService
    {
        Task CreateSellerAsync(CreateNewSellerRequestDto createNewSellerRequestDto);
        void CreateSeller(CreateNewSellerRequestDto createNewSellerRequestDto);
        Task DeleteSellerAsync(int sellerId);
        void DeleteSeller(int sellerId);
        Task UpdateSellerAsync(UpdateSellerRequestDto updateSellerRequestDto);
        void UpdateSeller(UpdateSellerRequestDto updateSellerRequestDto);
        SellerDisplayResponseDto GetSellerById(int sellerId);
        Task<SellerDisplayResponseDto> GetSellerByIdAsync(int sellerId);
        SellerDisplayResponseDto? GetSellerByUsername(string username);
        Task<SellerDisplayResponseDto>? GetSellerByUsernameAsync(string username);
    }
}
