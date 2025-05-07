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
            base.OnModelCreating(modelBuilder);
        }

        DbSet<Car> Cars { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Reservation> Reservations { get; set; }
    }
}
