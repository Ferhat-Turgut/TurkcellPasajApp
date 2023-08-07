﻿using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        Task<IEnumerable<Product>> GetAllAsync();

        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId);
        IEnumerable<Product> GetAllBySellerId(int sellerId);
        Task<IEnumerable<Product>> GetAllBySellerIdAsync(int sellerId);

        bool IsInStock(int productId);
        Task<bool> IsInStockAsync(int productId);
    }
}
