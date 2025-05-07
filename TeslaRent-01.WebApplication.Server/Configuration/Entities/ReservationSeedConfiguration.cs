using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Configuration.Entities
{
    public class ReservationSeedConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasData(
                // Palma Airport (18)
                new Reservation { Id = 1, CarId = 1, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 2, CarId = 4, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 3, CarId = 7, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 4, CarId = 10, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 5, CarId = 13, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 6, CarId = 16, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 7, CarId = 17, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 8, CarId = 19, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 9, CarId = 21, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 10, CarId = 23, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 11, CarId = 25, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 12, CarId = 27, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 13, CarId = 29, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 14, CarId = 32, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 15, CarId = 33, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 16, CarId = 35, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 17, CarId = 37, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 18, CarId = 38, StartLocationId = 1, EndLocationId = 1, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },

                // Palma City Center (13)
                new Reservation { Id = 19, CarId = 2, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 20, CarId = 5, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 21, CarId = 8, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 22, CarId = 11, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 23, CarId = 14, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 24, CarId = 18, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 25, CarId = 20, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 26, CarId = 22, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 27, CarId = 28, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 28, CarId = 30, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 29, CarId = 34, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 30, CarId = 36, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 31, CarId = 40, StartLocationId = 2, EndLocationId = 2, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },

                // Alcudia (5)
                new Reservation { Id = 32, CarId = 3, StartLocationId = 3, EndLocationId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 33, CarId = 6, StartLocationId = 3, EndLocationId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 34, CarId = 9, StartLocationId = 3, EndLocationId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 35, CarId = 24, StartLocationId = 3, EndLocationId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 36, CarId = 12, StartLocationId = 3, EndLocationId = 3, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },

                // Manacor (4)
                new Reservation { Id = 37, CarId = 15, StartLocationId = 4, EndLocationId = 4, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 38, CarId = 26, StartLocationId = 4, EndLocationId = 4, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 39, CarId = 31, StartLocationId = 4, EndLocationId = 4, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m },
                new Reservation { Id = 40, CarId = 39, StartLocationId = 4, EndLocationId = 4, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(-1), Price = 0.0m }
            );
        }
    }
}
