using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    internal interface ITeslaRentService
    {
        Task<List<LocationNameVM>> GetAvailableLocationVMsAsync();
        Task<List<CarModelVM>> GetAvailableCarVMsAsync(int startLocationId, int endLocationId, DateTime startDate, DateTime endDate);
        Task<ReservationDetailsVM> CreateReservationAsync(ReservationCreateVM reservationCreateVM);
        Task<MemoryStream> GetReservationDocument(ReservationDetailsVM reservationDetailsVM);
        Task<List<OurCarVM>> GetOurCarsVMAsync();
    }
}
