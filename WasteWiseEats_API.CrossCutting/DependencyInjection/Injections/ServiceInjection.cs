using Microsoft.Extensions.DependencyInjection;
using WasteWiseEats_API.Domain.Interfaces.Services;
using WasteWiseEats_API.Domain.Services;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public class ServiceInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
