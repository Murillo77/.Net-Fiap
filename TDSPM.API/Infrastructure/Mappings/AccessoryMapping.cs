using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSPM.API.Domain.Entity;

namespace TDSPM.API.Infrastructure.Mappings
{
    public class AccessoryMapping : IEntityTypeConfiguration<Accessory>
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {
            builder
                .ToTable("Accessory1");

            builder
                .Property(accessory => accessory.Name)
                .IsRequired();
        }
    }
}
