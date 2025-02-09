using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Application.Repositories;
using Task2.Domain.Entities;
using Task2.Infrastructure.Context;
using Task2.Infrastructure.Repositories;

namespace Task1.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

    }
}