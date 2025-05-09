using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Builders
{
    public class EmailBuilder : IEmailBuilder
    {
        public (string subject, string body) BuildReservationEmail(ReservationDetailsVM reservationDetailsVM)
        {
            string subject = "TeslaRent reservation confirmation";
            string body =
                $"Hi {reservationDetailsVM.ReservationCreateVM.FirstName} {reservationDetailsVM.ReservationCreateVM.LastName},\n\n" +
                $"Thank you for choosing Tesla Rent!\n\n" +
                $"Your reservation for a Tesla Model {reservationDetailsVM.CarModelName} in {reservationDetailsVM.StartLocationVM.Name} has been successfully confirmed.\n\n" +
                $"🗺️ **Pickup Location:**\n" +
                $"{reservationDetailsVM.StartLocationVM.Street} {reservationDetailsVM.StartLocationVM.StreetNumber},\n" +
                $"{reservationDetailsVM.StartLocationVM.ZipCode} {reservationDetailsVM.StartLocationVM.City}, {reservationDetailsVM.StartLocationVM.Country}\n\n" +
                $"📅 **Pickup Date:** {reservationDetailsVM.ReservationCreateVM.StartDate:dd/MM/yyyy} between 6:00 AM and 8:00 PM\n\n" +
                $"Please bring your ID or passport with you. The reservation must be paid within 24 hours of receiving this email.\n\n" +
                $"💳 **Payment Details:**\n" +
                $"Amount: {reservationDetailsVM.ReservationCreateVM.Price} EUR\n" +
                $"Account Name: Tesla Rent\n" +
                $"IBAN: ES76 1234 5678 9012 3456 7890\n" +
                $"BIC: MAJRESMMXXX\n\n" +
                $"🚗 **Return Location:** {reservationDetailsVM.EndLocationVM.Name}\n" +
                $"{reservationDetailsVM.EndLocationVM.Street} {reservationDetailsVM.EndLocationVM.StreetNumber},\n" +
                $"{reservationDetailsVM.EndLocationVM.ZipCode} {reservationDetailsVM.EndLocationVM.City}, {reservationDetailsVM.EndLocationVM.Country}\n\n" +
                $"📅 **Return Date:** {reservationDetailsVM.ReservationCreateVM.EndDate:dd/MM/yyyy} between 6:00 AM and 8:00 PM\n\n" +
                $"If you have any questions or need assistance, feel free to contact our support team at +34 123 456 789 or Tesla@Rent.com.\n\n" +
                $"Thank you once again, and we wish you a pleasant ride!\n\n" +
                $"Best regards,\n" +
                $"The Majorca TeslaRent Team";

            return (subject, body);
        }
    }
}
