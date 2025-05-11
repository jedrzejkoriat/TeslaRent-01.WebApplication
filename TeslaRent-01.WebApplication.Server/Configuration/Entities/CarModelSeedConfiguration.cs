using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Configuration.Entities
{
    internal sealed class CarModelSeedConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasData(
                new CarModel
                {
                    Id = 1,
                    Name = "Tesla Model 3",
                    BodyType = "Sedan",
                    Description = "A compact electric sedan offering high performance and range.",
                    DailyRateShortTerm = 220,
                    DailyRateMidTerm = 200,
                    DailyRateLongTerm = 165,
                    Seats = 5,
                    MaxSpeed = 261,
                    MaxRange = 491,
                    Acceleration = 3.1m
                },
                new CarModel
                {
                    Id = 2,
                    Name = "Tesla Model Y",
                    BodyType = "SUV",
                    Description = "A spacious electric SUV with advanced features and great range.",
                    DailyRateShortTerm = 350,
                    DailyRateMidTerm = 315,
                    DailyRateLongTerm = 270,
                    Seats = 5,
                    MaxSpeed = 217,
                    MaxRange = 499,
                    Acceleration = 5.0m
                },
                new CarModel
                {
                    Id = 3,
                    Name = "Tesla Model S",
                    BodyType = "Sedan",
                    Description = "A luxury electric sedan with impressive range and acceleration.",
                    DailyRateShortTerm = 500,
                    DailyRateMidTerm = 450,
                    DailyRateLongTerm = 375,
                    Seats = 5,
                    MaxSpeed = 322,
                    MaxRange = 652,
                    Acceleration = 2.1m
                },
                new CarModel
                {
                    Id = 4,
                    Name = "Tesla Model X",
                    BodyType = "SUV",
                    Description = "A premium electric SUV with falcon-wing doors and roomy interior.",
                    DailyRateShortTerm = 650,
                    DailyRateMidTerm = 600,
                    DailyRateLongTerm = 500,
                    Seats = 7,
                    MaxSpeed = 262,
                    MaxRange = 543,
                    Acceleration = 2.6m
                },
                new CarModel
                {
                    Id = 5,
                    Name = "Tesla Cybertruck",
                    BodyType = "Pickup",
                    Description = "A futuristic electric pickup truck built for durability and power.",
                    DailyRateShortTerm = 700,
                    DailyRateMidTerm = 640,
                    DailyRateLongTerm = 525,
                    Seats = 6,
                    MaxSpeed = 210,
                    MaxRange = 750,
                    Acceleration = 3.0m
                }
            );
        }
    }
}
