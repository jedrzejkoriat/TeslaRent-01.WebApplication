using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Configuration.Entities
{
    public class CarSeedConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                // Tesla Model 3 (16)
                new Car { Id = 1, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 2, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 3, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 4, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 5, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 6, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 7, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 8, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 9, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 10, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 11, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 12, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 13, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 14, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 15, CarModelId = 1, DaysInService = 0 },
                new Car { Id = 16, CarModelId = 1, DaysInService = 0 },

                // Tesla Model Y (10)
                new Car { Id = 17, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 18, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 19, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 20, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 21, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 22, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 23, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 24, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 25, CarModelId = 2, DaysInService = 0 },
                new Car { Id = 26, CarModelId = 2, DaysInService = 0 },

                // Tesla Model S (6)
                new Car { Id = 27, CarModelId = 3, DaysInService = 0 },
                new Car { Id = 28, CarModelId = 3, DaysInService = 0 },
                new Car { Id = 29, CarModelId = 3, DaysInService = 0 },
                new Car { Id = 30, CarModelId = 3, DaysInService = 0 },
                new Car { Id = 31, CarModelId = 3, DaysInService = 0 },
                new Car { Id = 32, CarModelId = 3, DaysInService = 0 },

                // Tesla Model X (6)
                new Car { Id = 33, CarModelId = 4, DaysInService = 0 },
                new Car { Id = 34, CarModelId = 4, DaysInService = 0 },
                new Car { Id = 35, CarModelId = 4, DaysInService = 0 },
                new Car { Id = 36, CarModelId = 4, DaysInService = 0 },
                new Car { Id = 37, CarModelId = 4, DaysInService = 0 },
                new Car { Id = 38, CarModelId = 4, DaysInService = 0 },

                // Tesla Cybertruck (2)
                new Car { Id = 39, CarModelId = 5, DaysInService = 0 },
                new Car { Id = 40, CarModelId = 5, DaysInService = 0 }
            );
        }
    }
}
