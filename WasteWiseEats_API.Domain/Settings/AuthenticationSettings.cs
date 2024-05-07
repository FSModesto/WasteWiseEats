namespace WhiteLabel.Domain.Settings
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }

        public int Expiration { get; set; }

        public string ApiKeySalt { get; set; }

        public string JokerPassword { get; set; }
    }
}
