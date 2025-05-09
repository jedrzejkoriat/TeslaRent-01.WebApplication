using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Builders
{
    public class EmailBuilder : IEmailBuilder
    {
        public (string subject, string body) BuildReservationEmail(ReservationDetailsVM reservationDetailsVM)
        {
            string subject = "TeslaRent reservation confirmation";
            string body = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Reservation Confirmation</title>
                </head>
                <body>
                    <p>Hi <strong>{reservationDetailsVM.ReservationCreateVM.FirstName} {reservationDetailsVM.ReservationCreateVM.LastName}</strong>,</p>

                    <p>Thank you for choosing TeslaRent!</p>

                    <p>Your reservation for a <strong>{reservationDetailsVM.ReservationCreateVM.CarModelName}</strong> in <strong>{reservationDetailsVM.StartLocationVM.Name}</strong> has been successfully confirmed.</p>

                    <h3>Pickup Location:</h3>
                    <p>{reservationDetailsVM.StartLocationVM.Street} {reservationDetailsVM.StartLocationVM.StreetNumber},<br>
                       {reservationDetailsVM.StartLocationVM.ZipCode} {reservationDetailsVM.StartLocationVM.City}, {reservationDetailsVM.StartLocationVM.Country}</p>

                    <h3>Pickup Date:</h3>
                    <p>{reservationDetailsVM.ReservationCreateVM.StartDate:dd/MM/yyyy} between 6:00 AM and 8:00 PM</p>

                    <p>Please bring your ID or passport with you. The reservation must be paid within 24 hours of receiving this email.</p>

                    <h3>Payment Details:</h3>
                    <p>Amount: {reservationDetailsVM.ReservationCreateVM.Price} EUR<br>
                       Account Name: Tesla Rent<br>
                       IBAN: ES76 1234 5678 9012 3456 7890<br>
                       BIC: MAJRESMMXXX</p>

                    <h3>Return Location:</h3>
                    <p>{reservationDetailsVM.EndLocationVM.Name}<br>
                       {reservationDetailsVM.EndLocationVM.Street} {reservationDetailsVM.EndLocationVM.StreetNumber},<br>
                       {reservationDetailsVM.EndLocationVM.ZipCode} {reservationDetailsVM.EndLocationVM.City}, {reservationDetailsVM.EndLocationVM.Country}</p>

                    <h3>Return Date:</h3>
                    <p>{reservationDetailsVM.ReservationCreateVM.EndDate:dd/MM/yyyy} between 6:00 AM and 8:00 PM</p>

                    <p>If you have any questions or need assistance, feel free to contact our support team at +34 123 456 789 or tesla@rent.com.</p>

                    <p>Thank you once again, and we wish you a pleasant ride!</p>

                    <p>Best regards,<br>
                       The Majorca TeslaRent Team</p>
                </body>
                </html>";

            return (subject, body);
        }
    }
}
