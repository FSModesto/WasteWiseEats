using Microsoft.Extensions.DependencyInjection;
using WasteWiseEats_API.Data.Repositories;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public static class RepositoryInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IWasteRegisterRepository, WasteRegisterRepository>();
            services.AddScoped<IDonationCenterRepository, DonationCenterRepository>();
            services.AddScoped<IDonationProposalRepository, DonationProposalRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISecurityProfileRepository, SecurityProfileRepository>();
        }
    }
}