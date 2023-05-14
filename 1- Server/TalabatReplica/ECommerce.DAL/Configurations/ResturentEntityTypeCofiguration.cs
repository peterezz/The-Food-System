using ECommerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DAL.Configurations
{
    public class RestaurantEntityTypeConfiguration : IEntityTypeConfiguration<Resturant>
    {
        public void Configure( EntityTypeBuilder<Resturant> builder )
        {
            builder.HasKey( key => key.RestaurantID );
            builder.Property( prop => prop.Name ).HasMaxLength( 50 );


        }
    }
}
