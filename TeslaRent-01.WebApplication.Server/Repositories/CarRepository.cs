using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddDaysToCarAsync(int carId, int daysInService)
        {
            Car car = await GetAsync(carId);
            car.DaysInService += daysInService;
            await UpdateAsync(car);
        }
    }
}
