using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSPM.API.Domain.Entity;

namespace TDSPM.API.Infrastructure.Mappings
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .ToTable("Cars1");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Plate)
                .IsRequired()                      // NOT NULL no banco
                .HasMaxLength(10);                // Limite de caracteres (ABC1234 / ABC1D23)

            builder
                .Property(c => c.Motorization)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.March)
                .IsRequired();

            builder
                .Property(c => c.BrandId)
                .IsRequired();

            builder
                .HasOne(c => c.Brand)
                .WithMany()
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
