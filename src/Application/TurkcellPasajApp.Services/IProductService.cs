using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;

namespace TurkcellPasajApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayResponseDto>>? GetAllProductsDisplayResponsesAsync();
        IEnumerable<ProductDisplayResponseDto>? GetAllProductsDisplayResponses();
        Task<IEnumerable<ProductDisplayResponseDto>>? GetAllProductsByCategoryIdAsync(int categoryId);
        IEnumerable<ProductDisplayResponseDto>? GetAllProductsByCategoryId(int categoryId);
        Task CreateProductAsync(CreateNewProductRequestDto createNewProductRequestDto);
        void CreateProduct(CreateNewProductRequestDto createNewProductRequestDto);
        Task DeleteProductAsync(int id);
        void DeleteProduct(int id);
        Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto);
        void UpdateProduct(UpdateProductRequestDto updateProductRequestDto);
        Task<ProductDisplayResponseDto>? GetProductByIdAsync(int productId);
        ProductDisplayResponseDto? GetProductById(int productId);
        Task<bool> IsInStockAsync(int productId);
        bool IsInStock(int productId);
    }
}
