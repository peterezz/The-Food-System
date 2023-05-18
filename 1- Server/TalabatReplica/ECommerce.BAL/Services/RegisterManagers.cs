using ECommerce.BAL.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.BAL.Services
{
    public static class RegisterManagers
    {
        public static IServiceCollection AddManagersServices( this IServiceCollection services )
        {
            services.AddScoped<TestManager>( );
            services.AddScoped<MenueItemManager>();


            return services;
        }
    }
}
