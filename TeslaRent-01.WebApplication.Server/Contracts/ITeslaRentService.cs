using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface ITeslaRentService
    {
        Task<List<LocationNameVM>> GetAvailableLocationVMsAsync();
        Task<List<CarModelVM>> GetAvailableCarVMsAsync(ReservationSearchVM reservationSearchVM);
        Task CreateReservationAsync(ReservationCreateVM reservationCreateVM);
    }
}
