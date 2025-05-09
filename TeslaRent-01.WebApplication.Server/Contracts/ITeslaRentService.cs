using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface ITeslaRentService
    {
        Task<List<LocationNameVM>> GetAvailableLocationVMsAsync();
        Task<List<CarModelVM>> GetAvailableCarVMsAsync(ReservationSearchVM reservationSearchVM);
        Task<MemoryStream> CreateReservationAsync(ReservationCreateVM reservationCreateVM);
    }
}
