using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.UoW;
using WasteWiseEats_API.Domain.Interfaces.UoW;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection.Injections
{
    public class ContextInjection
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            //Contexts
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<WasteWiseEatsContext>(options => options.UseSqlServer(configuration.GetConnectionString("WasteWiseEatsConnection")));

            // UoW - Unit of Work
            services.AddScoped<IWasteWiseEatsUoW, WasteWiseEatsUoW>();
        }
    }
}
