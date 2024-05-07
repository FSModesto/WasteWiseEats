using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;
using WasteWiseEats_API.Domain.Models.Authentications;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.User
{
    public class UserAuthenticationCommand : Command<Authenticated<AuthenticatedUser>>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
