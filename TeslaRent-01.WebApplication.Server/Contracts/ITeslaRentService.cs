using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    internal interface ITeslaRentService
    {
        Task<List<LocationNameVM>> GetAvailableLocationVMsAsync();
        Task<List<CarModelVM>> GetAvailableCarVMsAsync(int startLocationId, int endLocationId, DateTime startDate, DateTime endDate);
        Task<MemoryStream> CreateReservationAsync(ReservationCreateVM reservationCreateVM);
    }
}
