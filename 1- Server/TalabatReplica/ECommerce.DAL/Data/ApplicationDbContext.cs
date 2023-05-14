using ECommerce.DAL.Configurations;
using ECommerce.DAL.Models;
using ECommerce.DAL.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options )
        {

        }


        protected override void OnModelCreating( ModelBuilder model )
        {
            base.OnModelCreating( model );
            model.ApplyConfigurationsFromAssembly( typeof( ResturentEntityTypeCofiguration ).Assembly );
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Test> Tests { get; set; }

    }
}
