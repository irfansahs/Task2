using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Task2.Application.Dtos;
using Task2.Application.Dtos;
using Task2.Application.Repositories;
using Task2.Domain.Entities;

namespace Task2.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(
            IUnitOfWork unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task AddProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product != null)
            {
                await _unitOfWork.Products.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public Task AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
