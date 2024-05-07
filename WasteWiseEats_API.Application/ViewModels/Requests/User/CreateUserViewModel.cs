namespace WasteWiseEats_API.Application.ViewModels.Requests.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public Guid ProfileId { get; set; }
    }
}
