using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSPM.API.Domain.Entity;

namespace TDSPM.API.Infrastructure.Mappings
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .ToTable("Brand1");

            builder
                .HasKey("Id");

            builder
                .Property(brand => brand.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(b => b.Cars)
                .WithOne(b => b.Brand)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
