using Microsoft.EntityFrameworkCore;
using TDSPM.API.Domain.Entity;
using TDSPM.API.Infrastructure.Mappings;

namespace TDSPM.API.Infrastructure.Context
{
    public class CarContext(DbContextOptions<CarContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Brand> Brands { get; set; }

        //public DbSet<Accessory> Accessories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMapping());
            modelBuilder.ApplyConfiguration(new BrandMapping());
            //modelBuilder.ApplyConfiguration(new AccessoryMapping());
        }
    }
}
