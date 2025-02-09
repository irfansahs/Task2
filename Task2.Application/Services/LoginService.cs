using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Application.Dtos;
using Task2.Application.Repositories;
using Task2.Domain.Entities;

namespace Task2.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByConditionAsync(u => u.Username == loginDto.UserName);
            if (user == null)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı!");

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Geçersiz şifre!");

            return _tokenService.GenerateToken(user);
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByConditionAsync(u => u.Username == registerDto.Username);
            if (existingUser != null)
                throw new Exception("Kullanıcı zaten mevcut!");

            string passwordHash = HashPassword(registerDto.Password);

            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,

            };

            await _userRepository.AddAsync(user);
            return _tokenService.GenerateToken(user);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}