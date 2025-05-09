using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    public interface IEmailBuilder
    {
        (string subject, string body) BuildReservationEmail(ReservationDetailsVM reservationDetailsVM);
    }
}
