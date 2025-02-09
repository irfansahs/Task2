using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Domain.Entities;

namespace Task2.Application.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        
    }
}