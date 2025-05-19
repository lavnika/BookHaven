using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BookRentalAPI.Models.Entities;

namespace BookRentalAPI.Helpers
{
    public class JwtHelper
    {
        public static string GenerateJwtToken(User user, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");
            var secret = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"]));

            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim("id", user.Id.ToString()),
            new Claim("fullName", user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            if (!string.IsNullOrWhiteSpace(user.City))
                claims.Add(new Claim("City", user.City));

            if (!string.IsNullOrWhiteSpace(user.Address))
                claims.Add(new Claim("Address", user.Address));

            if (user.Latitude.HasValue)
                claims.Add(new Claim("Latitude", user.Latitude.Value.ToString()));

            if (user.Longitude.HasValue)
                claims.Add(new Claim("Longitude", user.Longitude.Value.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
