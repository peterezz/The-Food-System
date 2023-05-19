using ECommerce.API.Cofigurations.Filters;
using ECommerce.BAL.Services;
using ECommerce.DAL.Models.IdentityModels;
using ECommerce.DAL.Reposatory.Repo;
using ECommerce.DAL.Reposatory.RepoServices;
using ECommerce.DAL.Services;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //mapping values of JWT section in json file to properties in JWT class

            builder.Configuration.GetSection("JWT").Get<JWTData>();

            var connectionString = builder.Configuration.GetConnectionString("MyConn");

            builder.Services.AddDbContext<ApplicationDbContext>(options => { 
                options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }) ;
            

            //Define Identity Services
            builder.Services.AddIdentity<ApplicationUser , IdentityRole>( )
                .AddEntityFrameworkStores<ApplicationDbContext>( );

            //add my own components
            builder.Services.AddScoped<IAouthRepo , AuthServices>( );


            //add JWT Configuration

            builder.Services.AddAuthentication( option =>
            {
                //Define JWT Default schema instead write it with each [Authorize] data annotation

                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            } )
                // Define place of key , issuer , ... to validate it and how & which data need to validate and which not 
                .AddJwtBearer( o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    /*The most important*/
                    o.TokenValidationParameters = new TokenValidationParameters
                    {

                        //define which datawill be validate
                        ValidateIssuerSigningKey = true ,
                        ValidateIssuer = true ,
                        ValidateAudience = true ,
                        ValidateLifetime = true ,

                        //define data to compare with it
                        ValidIssuer = builder.Configuration[ "JWT:Issuer" ] ,
                        ValidAudience = builder.Configuration[ "JWT:Audience" ] ,
                        IssuerSigningKey = new SymmetricSecurityKey
                                               ( Encoding.UTF8.GetBytes( builder.Configuration[ "JWT:Key" ] ) ) ,
                        ClockSkew = TimeSpan.Zero // to expire token after determined time not set delay time after expiration                

                    };
                } );

            await builder.Services.AddIdentityService();

            await builder.Services.AddIdentityService( );
            builder.Services.AddBaseRepo( );
            builder.Services.AddAutoMapper( );
            builder.Services.AddManagersServices( );
            builder.Services.AddControllers( options =>
            {
                options.Filters.Add( new ExceptionFilter( builder.Environment ) );
            } ).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore);;


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

            app.UseAuthentication( );

            app.UseAuthorization( );

            app.MapControllers( );

            app.Run( );
        }
    }
}