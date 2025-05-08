using Microsoft.EntityFrameworkCore;
using TeslaRent_01.WebApplication.Server.Configuration.Entities;
using TeslaRent_01.WebApplication.Server.Models;

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
                .HasOne(c => c.CarModel)
                .WithMany()
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.StartLocation)
                .WithMany()
                .HasForeignKey(r => r.StartLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.EndLocation)
                .WithMany()
                .HasForeignKey(r => r.EndLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // View models for sql queries
            modelBuilder.Entity<CarModelVM>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<CarVM>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.ApplyConfiguration(new CarModelSeedConfiguration());
            modelBuilder.ApplyConfiguration(new CarSeedConfiguration());
            modelBuilder.ApplyConfiguration(new LocationSeedConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationSeedConfiguration());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties()
                    .Where(p => p.ClrType == typeof(string) && p.GetMaxLength() == null);

                foreach (var property in properties)
                {
                    property.SetMaxLength(255);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Car> Cars { get; set; }
        DbSet<CarModel> CarModels { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<CarModelVM> AvailableCarModelVMs { get; set; }
        DbSet<CarVM> AvailableCarVMs { get; set; }
    }
}
