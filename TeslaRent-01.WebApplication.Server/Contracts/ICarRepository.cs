using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    internal interface ICarRepository : IGenericRepository<Car>
    {
        Task AddDaysToCarAsync(int carId, int daysInService);
    }
}
