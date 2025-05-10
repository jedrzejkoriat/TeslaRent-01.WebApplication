namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface ICarRepository
    {
        Task AddDaysToCarAsync(int carId, int daysInService);
    }
}
