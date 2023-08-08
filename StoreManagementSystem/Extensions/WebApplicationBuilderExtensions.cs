using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Services;

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
    }
}
