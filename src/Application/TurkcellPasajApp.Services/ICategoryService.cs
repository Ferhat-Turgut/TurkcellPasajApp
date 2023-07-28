using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDisplayResponseDto>>? GetAllCategoryDisplayResponsesAsync();
        IEnumerable<CategoryDisplayResponseDto>? GetAllCategoryDisplayResponses();
        Task CreateCategoryAsync(CreateNewCategoryRequestDto createNewCategoryRequestDto);
        void CreateCategory(CreateNewCategoryRequestDto createNewCategoryRequestDto);
        Task UpdateCategoryAsync(UpdateCategoryRequestDto updateCategoryRequestDto);
        void UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto);
        Task<CategoryDisplayResponseDto> GetCategoryByIdAsync(int categoryId);
        CategoryDisplayResponseDto GetCategoryById(int categoryId);
    }
}
