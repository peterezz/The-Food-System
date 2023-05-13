using ECommerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DAL.Configurations
{
    public class ResturentEntityTypeCofiguration : IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            builder.HasKey(key => key.ResturantID);
            builder.Property(prop => prop.Name).HasMaxLength(50);
            

        }
    }
}
