using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial3_AriasRoldanNatalia.DAL.Entities;

namespace Parcial3_AriasRoldanNatalia.DAL
{

    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Services> Servicies { get; set; }
        public DbSet<Vehicles> Vehicules { get; set; }
        public DbSet<VehicleDetails> VehiculesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Services>().HasIndex(c => c.Name).IsUnique();
        }
    }

}
