using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WasteWiseEats_API.Domain.CommandHandlers;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public class MediatRInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddMediatR(typeof(DonationCenterCommandHandler).Assembly,
                                typeof(DonationProposalCommandHandler).Assembly,
                                typeof(EmployeeCommandHandler).Assembly,
                                typeof(RestaurantCommandHandler).Assembly,
                                typeof(UserCommandHandler).Assembly,
                                typeof(WasteRegisterCommandHandler).Assembly);
        }
    }
}
