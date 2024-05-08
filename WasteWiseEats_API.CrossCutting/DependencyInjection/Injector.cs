using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WasteWiseEats_API.Application.AutoMapper;
using WasteWiseEats_API.CrossCutting.DependencyInjection.Injections;
using WhiteLabel.Domain.Settings;

namespace WasteWiseEats_API.CrossCutting.DependencyInjection
{
    public static class Injector
    {
        public static void InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            AppServiceInjection.Inject(services);
            ContextInjection.Inject(services, configuration);
            RepositoryInjection.Inject(services);
            ServiceInjection.Inject(services);
            MediatRInjection.Inject(services);
            SettingsInjection.Inject(services, configuration);

            AddJwtAuthentication(services, configuration);
            ConfigureAutoMapper(services);
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileToCommand), typeof(ProfileToViewModel), typeof(ProfileToModel));
        }

        private static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            AuthenticationSettings authSettings =
                configuration.GetSection(nameof(AuthenticationSettings)).Get<AuthenticationSettings>();

            byte[] key = Encoding.ASCII.GetBytes(authSettings.JwtKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}