using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.User
{
    public class UserCommand<TResponse> : Command<TResponse>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public Guid ProfileId { get; set; }
    }
}