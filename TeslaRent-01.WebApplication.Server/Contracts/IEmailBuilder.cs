using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Contracts
{
    internal interface IEmailBuilder
    {
        (string subject, string body) BuildReservationEmail(ReservationDetailsVM reservationDetailsVM);
    }
}
