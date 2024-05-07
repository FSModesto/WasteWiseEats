namespace WasteWiseEats_API.Domain.Models.Authentications
{
    public class Authenticated<TContext>
    {
        public string Token { get; set; }

        public string Type { get; set; }

        public DateTime ExpiresAt { get; set; }

        public TContext Context { get; set; }
    }
}
