using Almacen.Application.Contracts.Identity;
using Almacen.Domain.EntityModels.Authorization;
using Almacen.Infrastructure.Authorization;
using Almacen.Infrastructure.Services;
using Almacen.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Infrastruture
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructure
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("Default")); });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            }).AddGoogle(options => {
                options.ClientId = configuration["authentication:google:clientId"];
                options.ClientSecret = configuration["authentication:google:clientSecret"];
                options.SignInScheme = IdentityConstants.ExternalScheme;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyTypes.Guests.Read,
                    policy =>
                    {
                        // Lista de permisos asociado con controlador y una lista depermisos
                        policy.AddRequirements(new PolicyRequirement
                            (new List<PolicyPermission>()
                            {
                                new PolicyPermission("Home", "Guests")
                            }
                            ));
                    });
            });
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
