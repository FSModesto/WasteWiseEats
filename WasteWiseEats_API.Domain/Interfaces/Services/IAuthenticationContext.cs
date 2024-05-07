using System.Security.Claims;

namespace WasteWiseEats_API.Domain.Interfaces.Services
{
    public interface IAuthenticationContext
    {
        abstract ClaimsIdentity GetClaims();

        abstract IAuthenticationContext WithClaims(IEnumerable<Claim> claims);
    }
}
