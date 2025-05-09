using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface IPdfBuilder
    {
        public MemoryStream BuildReservationPdf(ReservationDetailsVM reservationDetailsVM);
    }
}
