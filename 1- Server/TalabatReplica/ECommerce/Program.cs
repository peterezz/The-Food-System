using ECommerce.BAL.Services;
using ECommerce.DAL.Services;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce
{
    public class Program
    {
        public static async Task Main( string[ ] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.

            //mapping values of JWT section in json file to properties in JWT class

            builder.Configuration.GetSection( "JWT" ).Get<JWTData>( );

            var connectionString = builder.Configuration.GetConnectionString( "MyConn" );

            builder.Services.AddDbContext<ApplicationDbContext>( options =>
                options.UseSqlServer( connectionString ) );


            //Define Identity Services
            builder.Services.AddIdentity<IdentityUser , IdentityRole>( )
                .AddEntityFrameworkStores<ApplicationDbContext>( );

            await builder.Services.AddIdentityService( );

            builder.Services.AddBaseRepo( );
            builder.Services.AddAutoMapper( );
            builder.Services.AddManagersServices( );

            builder.Services.AddControllers( );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer( );
            builder.Services.AddSwaggerGen( );

            var app = builder.Build( );

            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment( ) )
            {
                app.UseSwagger( );
                app.UseSwaggerUI( );
            }

            app.UseHttpsRedirection( );

            app.UseAuthorization( );


            app.MapControllers( );



            app.Run( );
        }
    }
}