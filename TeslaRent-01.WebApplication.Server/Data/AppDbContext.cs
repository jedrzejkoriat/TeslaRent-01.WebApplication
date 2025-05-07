using Microsoft.EntityFrameworkCore;

namespace TeslaRent_01.WebApplication.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany()
                .HasForeignKey(c => c.ModelId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.StartLocation)
                .WithMany()
                .HasForeignKey(r => r.StartLocationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.EndLocation)
                .WithMany()
                .HasForeignKey(r => r.EndLocationId);

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Car> Cars { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Reservation> Reservations { get; set; }
    }
}
