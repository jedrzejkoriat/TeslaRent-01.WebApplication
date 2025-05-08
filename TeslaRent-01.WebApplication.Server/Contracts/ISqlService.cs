using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface ISqlService
    {
        Task<List<AvailableCarsVM>> GetAvailableCarsVMAsync(ReservationSearchVM reservationSearchVM);
    }
}
