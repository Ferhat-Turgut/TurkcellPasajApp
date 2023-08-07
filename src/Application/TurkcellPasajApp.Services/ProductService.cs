using AutoMapper;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Infrastructure.Repositories;

namespace TurkcellPasajApp.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void CreateProduct(CreateNewProductRequestDto createNewProductRequestDto)
        {
            var product = _mapper.Map<Product>(createNewProductRequestDto);
            _productRepository.Create(product);
        }

        public async Task CreateProductAsync(CreateNewProductRequestDto createNewProductRequestDto)
        {
            var product =_mapper.Map<Product>(createNewProductRequestDto);
             await _productRepository.CreateAsync(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public IEnumerable<ProductDisplayResponseDto>? GetAllProductsByCategoryId(int categoryId)
        {
            var productsByCategory=_productRepository.GetAllByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(productsByCategory);
        }

        public async Task<IEnumerable<ProductDisplayResponseDto>>? GetAllProductsByCategoryIdAsync(int categoryId)
        {
            var productsByCategory =await _productRepository.GetAllByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(productsByCategory);
        }

        public IEnumerable<ProductDisplayResponseDto>? GetAllProductsBySelleryId(int sellerId)
        {
            var productsBySeller = _productRepository.GetAllBySellerId(sellerId);
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(productsBySeller);
        }

        public async Task<IEnumerable<ProductDisplayResponseDto>>? GetAllProductsBySelleryIdAsync(int sellerId)
        {
            var productsBySeller =await _productRepository.GetAllBySellerIdAsync(sellerId);
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(productsBySeller);
        }

        public IEnumerable<ProductDisplayResponseDto>? GetAllProductsDisplayResponses()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(products);
        }

        public async Task<IEnumerable<ProductDisplayResponseDto>>? GetAllProductsDisplayResponsesAsync()
        {
            var products =await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDisplayResponseDto>>(products);
        }

        public ProductDisplayResponseDto? GetProductById(int productId)
        {
            var product = _productRepository.Get(productId);
            return _mapper.Map<ProductDisplayResponseDto>(product);
        }

        public async Task<ProductDisplayResponseDto>? GetProductByIdAsync(int productId)
        {
            var product =await _productRepository.GetAsync(productId);
            return _mapper.Map<ProductDisplayResponseDto>(product);
        }

        public bool IsInStock(int productId)
        {
            return _productRepository.IsInStock(productId);
        }

        public async Task<bool> IsInStockAsync(int productId)
        {
            return await _productRepository.IsInStockAsync(productId);
        }

        public void UpdateProduct(UpdateProductRequestDto updateProductRequestDto)
        {
            var product = _mapper.Map<Product>(updateProductRequestDto);
            _productRepository.Update(product);
        }

        public async Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto)
        {
            var product = _mapper.Map<Product>(updateProductRequestDto);
            await _productRepository.UpdateAsync(product);
        }
    }
}
