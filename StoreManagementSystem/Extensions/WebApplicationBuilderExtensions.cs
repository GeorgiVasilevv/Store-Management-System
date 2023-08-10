using Microsoft.AspNetCore.Identity;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Data.Entities.Models;
using StoreManagementSystem.Middlewares;
using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder application, string email)
        {
            using IServiceScope scopedServices = application.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                User futureAdmin = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(futureAdmin, AdminRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return application;
        }

        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OnlineUsersMiddleware>();
        }
    }
}
