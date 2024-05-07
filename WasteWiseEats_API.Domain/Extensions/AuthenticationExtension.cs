using System.Security.Claims;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class AuthenticationExtension
    {
        public static T GetClaim<T>(this IEnumerable<Claim> claims, string claimType, T @default = default)
        {
            if (claims == null || !claims.Any())
                return @default;

            string claimValue =
                claims.Where(claim => claim.Type == claimType)
                      .Select(claim => claim.Value)
                      .FirstOrDefault();

            if (string.IsNullOrEmpty(claimValue))
                return @default;

            return claimValue.Convert(@default);
        }

        public static IEnumerable<T> GetClaims<T>(this IEnumerable<Claim> claims, string claimType, T @default = default)
        {
            if (claims == null || !claims.Any())
                return Enumerable.Empty<T>();

            IEnumerable<string> claimValues =
                claims.Where(claim => claim.Type == claimType)
                      .Select(claim => claim.Value);

            return claimValues.Select(claimValue => claimValue.Convert(@default));
        }
    }
}
