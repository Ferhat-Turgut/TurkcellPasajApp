using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void CreateCategory(CreateNewCategoryRequestDto createNewCategoryRequestDto)
        {
            var newCategory = _mapper.Map<Category>(createNewCategoryRequestDto);
            _categoryRepository.Create(newCategory);
        }

        public async Task CreateCategoryAsync(CreateNewCategoryRequestDto createNewCategoryRequestDto)
        {
            var newCategory = _mapper.Map<Category>(createNewCategoryRequestDto);
            await _categoryRepository.CreateAsync(newCategory);
        }

        public IEnumerable<CategoryDisplayResponseDto>? GetAllCategoryDisplayResponses()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDisplayResponseDto>>(categories);
        }

        public async Task<IEnumerable<CategoryDisplayResponseDto>>? GetAllCategoryDisplayResponsesAsync()
        {
            var categories =await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDisplayResponseDto>>(categories);
        }

        public CategoryDisplayResponseDto GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.Get(categoryId);
            return _mapper.Map<CategoryDisplayResponseDto>(category);
        }

        public async Task<CategoryDisplayResponseDto> GetCategoryByIdAsync(int categoryId)
        {
            var category =await _categoryRepository.GetAsync(categoryId);
            return _mapper.Map<CategoryDisplayResponseDto>(category);
        }

        public void UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            var updateCategory = _mapper.Map<Category>(updateCategoryRequestDto);
            _categoryRepository.Update(updateCategory);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            var updateCategory = _mapper.Map<Category>(updateCategoryRequestDto);
            await _categoryRepository.UpdateAsync(updateCategory);
        }
    }
}
