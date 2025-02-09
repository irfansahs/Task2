using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Application.Dtos;

namespace Task2.Application.Services
{
     public interface ILoginService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}