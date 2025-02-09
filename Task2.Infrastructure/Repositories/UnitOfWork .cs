using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Repositories;
using Task2.Infrastructure.Context;

namespace Task2.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }

    public UnitOfWork(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

}