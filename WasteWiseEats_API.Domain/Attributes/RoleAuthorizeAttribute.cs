using Microsoft.AspNetCore.Authorization;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Extensions;

namespace WasteWiseEats_API.Domain.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(params ERole[] roles)
        {
            Roles = string.Join(",", roles.Select(role => role.GetDescription()));
        }
    }
}
