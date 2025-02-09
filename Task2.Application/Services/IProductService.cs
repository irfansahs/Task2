using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Application.Dtos;
using Task2.Domain.Entities;

namespace Task2.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDto product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}