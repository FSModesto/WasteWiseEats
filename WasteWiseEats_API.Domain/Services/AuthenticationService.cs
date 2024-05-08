using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WasteWiseEats_API.Domain.Interfaces.Services;
using WasteWiseEats_API.Domain.Models.Authentications;
using WhiteLabel.Domain.Settings;

namespace WasteWiseEats_API.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const int HASH_SIZE = 16;
        private const int ITERATIONS = 50;
        private const int MEMORY_SIZE = 1024;
        private const int PARALLELISM = 2;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationSettings? _settings;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenereateSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(HASH_SIZE);

            return Convert.ToHexString(salt);
        }

        public string GenerateRandomPassword(int lenght = 15)
        {
            Random random = new();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*+-=;:,.<>?";

            return new string(
                Enumerable.Repeat(chars, lenght)
                          .Select(_char => _char[random.Next(_char.Length)])
                          .ToArray());
        }

        public string HashPassword(string password, string salt)
        {
            byte[] _salt = Encoding.ASCII.GetBytes(salt);
            byte[] _password = Encoding.ASCII.GetBytes(password);

            Argon2id argon = new(_password)
            {
                Salt = _salt,
                Iterations = ITERATIONS,
                MemorySize = MEMORY_SIZE,
                DegreeOfParallelism = PARALLELISM,
            };

            byte[] hash = argon.GetBytes(HASH_SIZE);

            return Convert.ToHexString(hash);
        }

        public Authenticated<TContext> Authenticate<TContext>(TContext context) where TContext : IAuthenticationContext
        {
            byte[] key = Encoding.ASCII.GetBytes(_settings.JwtKey);

            DateTime expiration = DateTime.UtcNow.AddMinutes(_settings.Expiration);

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = context.GetClaims(),
                Expires = expiration,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            string token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new Authenticated<TContext>()
            {
                Token = token,
                ExpiresAt = expiration,
                Type = "Bearer",
                Context = context
            };
        }

        public Guid GetUserIdFromToken()
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            string token = authorizationHeader.Substring("Bearer ".Length).Trim();

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out _);

            return new Guid(claimsPrincipal.FindFirst(ClaimTypes.PrimarySid).Value);
        }
    }
}
