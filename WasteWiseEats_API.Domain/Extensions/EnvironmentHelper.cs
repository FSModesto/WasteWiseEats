namespace WasteWiseEats_API.Domain.Extensions
{
    public static class EnvironmentHelper
    {
        public static string GetEnvironment(string environment = "ASPNETCORE_ENVIRONMENT")
        {
            return Environment.GetEnvironmentVariable(environment);
        }

        public static bool IsProduction()
        {
            string environment = GetEnvironment();

            return string.IsNullOrEmpty(environment) || environment == "Production";
        }

        public static bool IsDevelopment()
        {
            string environment = GetEnvironment();

            return environment == "Development" || environment == "Local";
        }

        public static bool IsStaging()
        {
            string environment = GetEnvironment();

            return environment == "Staging";
        }

        public static string GetEnvironmentMinified(bool localAsDev = false)
        {
            string env = GetEnvironment() ?? "";

            return env.ToLower() switch
            {
                "production" or "" => "PRD",
                "staging" => "HMG",
                "development" => "DEV",
                "local" => localAsDev ? "DEV" : "LOC",
                _ => ""
            };
        }
    }
}
