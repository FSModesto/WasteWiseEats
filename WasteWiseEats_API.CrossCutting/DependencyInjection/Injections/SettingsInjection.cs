using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhiteLabel.Domain.Settings;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public class SettingsInjection
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationSettings>(configuration.GetSection(nameof(AuthenticationSettings)));
        }
    }
}
