using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Domain.Entities;

namespace Task2.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        User ValidateToken(string token);
    }

}