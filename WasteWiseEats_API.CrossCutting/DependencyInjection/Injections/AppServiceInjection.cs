using Microsoft.Extensions.DependencyInjection;
using WasteWiseEats_API.Application.AppServices;
using WasteWiseEats_API.Application.AppServices.Interfaces;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public class AppServiceInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IDashboardAppService, DashboardAppService>();
            services.AddScoped<IRestaurantAppService, RestaurantAppService>();
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IWasteRegisterAppService, WasteRegisterAppService>();
            services.AddScoped<IDonationCenterAppService, DonationCenterAppService>();
            services.AddScoped<IDonationProposalAppService, DonationProposalAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
