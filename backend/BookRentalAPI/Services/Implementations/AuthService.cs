using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookRentalAPI.Data;
using BookRentalAPI.Models.DTOs;
using BookRentalAPI.Models.Entities;
using BookRentalAPI.Helpers;
using BookRentalAPI.Services.Interfaces;

namespace BookRentalAPI.Services.Implementations
{

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new ApplicationException("Email already in use.");

            using var hmac = new HMACSHA512();
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // return JWT
            return JwtHelper.GenerateJwtToken(user, _config);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                throw new ApplicationException("Invalid credentials.");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                throw new ApplicationException("Invalid credentials.");

            // return JWT
            return JwtHelper.GenerateJwtToken(user, _config);
        }
    }
}
