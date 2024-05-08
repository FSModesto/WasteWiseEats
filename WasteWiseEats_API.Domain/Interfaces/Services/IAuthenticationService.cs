using WasteWiseEats_API.Domain.Models.Authentications;

namespace WasteWiseEats_API.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GenereateSalt();

        string GenerateRandomPassword(int lenght = 15);

        string HashPassword(string password, string salt);

        Authenticated<TContext> Authenticate<TContext>(TContext context) where TContext : IAuthenticationContext;

        Guid GetUserIdFromToken();
    }
}
