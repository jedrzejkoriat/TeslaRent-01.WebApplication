using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Configuration.Entities
{
    public class CarModelSeedConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasData(
                new CarModel { Id = 1, Name = "Tesla Model 3", DailyRateShortTerm = 220, DailyRateMidTerm = 200, DailyRateLongTerm = 165 },
                new CarModel { Id = 2, Name = "Tesla Model Y", DailyRateShortTerm = 350, DailyRateMidTerm = 315, DailyRateLongTerm = 270 },
                new CarModel { Id = 3, Name = "Tesla Model S", DailyRateShortTerm = 500, DailyRateMidTerm = 450, DailyRateLongTerm = 375 },
                new CarModel { Id = 4, Name = "Tesla Model X", DailyRateShortTerm = 650, DailyRateMidTerm = 600, DailyRateLongTerm = 500 },
                new CarModel { Id = 5, Name = "Tesla Cybertruck", DailyRateShortTerm = 700, DailyRateMidTerm = 640, DailyRateLongTerm = 525 }
                );
        }
    }
}
