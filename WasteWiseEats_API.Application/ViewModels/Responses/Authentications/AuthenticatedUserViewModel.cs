namespace WasteWiseEats_API.Application.ViewModels.Responses.Authentications
{
    public class AuthenticatedUserViewModel
    {
        public AuthenticatedUserViewModel()
        {
            Roles = Enumerable.Empty<string>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Profile { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
