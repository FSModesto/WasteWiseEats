
using System.Security.Claims;
using WasteWiseEats_API.Domain.Extensions;
using WasteWiseEats_API.Domain.Interfaces.Services;

namespace WasteWiseEats_API.Domain.Models.Authentications
{
    public class AuthenticatedUser : IAuthenticationContext
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Profile { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public ClaimsIdentity GetClaims()
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.PrimarySid, Id.ToString()),
                new Claim(ClaimTypes.Name, Name),
                new Claim(nameof(Profile), Profile)
            };

            foreach (string role in Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return new ClaimsIdentity(claims);
        }

        public IAuthenticationContext WithClaims(IEnumerable<Claim> claims)
        {
            Id = claims.GetClaim<Guid>(ClaimTypes.PrimarySid);
            Name = claims.GetClaim<string>(ClaimTypes.Name);
            Profile = claims.GetClaim<string>(nameof(Profile));
            Roles = claims.GetClaims<string>(ClaimTypes.Role);

            return this;
        }
    }
}
