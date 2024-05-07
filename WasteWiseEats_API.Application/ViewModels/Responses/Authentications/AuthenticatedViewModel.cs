namespace WasteWiseEats_API.Application.ViewModels.Responses.Authentications
{
    public class AuthenticatedViewModel<TContext>
    {
        public string Token { get; set; }

        public string Type { get; set; }

        public DateTime ExpiresAt { get; set; }

        public TContext Context { get; set; }
    }
}
