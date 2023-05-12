using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ECommerce.DAL.Services
{
    public static class RegisterServices
    {
        public static async Task<IServiceCollection> RegisterIdentityService( this IServiceCollection service )
        {
            #region Dfault Roles
            var _serviceProvider = service.BuildServiceProvider( );
            var scope = _serviceProvider.CreateScope( );
            var services = scope.ServiceProvider;
            // created logger service
            var loggerFactory = services.GetRequiredService<ILoggerFactory>( );
            var _logger = loggerFactory.CreateLogger( "app" );
            // created role manager service
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>( );
            await Seed.DefaultRole.SeedRoles( _roleManager );
            _logger.Log( LogLevel.Information , "registered default roles" );
            return service;


            #endregion
        }
    }
}
