using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSPM.API.Domain.Entity;

namespace TDSPM.API.Infrastructure.Mappings
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("CarKeller");

            builder.HasKey("Id");

            builder
                .Property(car => car.Plate)
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property(car => car.BrandId)
                .IsRequired();

            builder
                .Property(car => car.Motorization)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
