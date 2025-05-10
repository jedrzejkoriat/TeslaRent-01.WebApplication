using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task AddDaysToCarAsync(int carId, int daysInService);
    }
}
