using PdfSharp.Drawing;
using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TeslaRent_01.WebApplication.Server.Builders
{
    public class PdfBuilder : IPdfBuilder
    {
        public MemoryStream BuildReservationPdf(ReservationDetailsVM reservationDetailsVM)
        { 
            // Create document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Reservation Confirmation";

            // Create page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Fonts
            XFont fontNormal = new XFont("Arial", 12);
            XFont fontBold = new XFont("Arial", 12, XFontStyleEx.Bold);

            // Margins
            double margin = 40;
            double yPosition = margin;

            gfx.DrawString("Reservation Confirmation", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Thank you for choosing TeslaRent!", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Your reservation for a Tesla car has been successfully confirmed.", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            // Pickup Location
            gfx.DrawString("Pickup Location:", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Street: Main Street 123", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("City: Palma, Mallorca", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("Zip Code: 07001", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            // Pickup Date
            gfx.DrawString("Pickup Date:", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("May 15, 2025 between 6:00 AM and 8:00 PM", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            // Payment Details
            gfx.DrawString("Payment Details:", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Amount: 100.00 EUR", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("Account Name: Tesla Rent", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("IBAN: ES76 1234 5678 9012 3456 7890", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("BIC: MAJRESMMXXX", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            // Return Location
            gfx.DrawString("Return Location:", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Tesla Rent Office, Palma", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("Street: Return St. 45", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("Zip Code: 07002", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            // Return Date
            gfx.DrawString("Return Date:", fontBold, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("May 22, 2025 between 6:00 AM and 8:00 PM", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 50;

            // Contact Information
            gfx.DrawString("If you have any questions, feel free to contact our support team at +34 123 456 789 or tesla@rent.com.", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Thank you once again, and we wish you a pleasant ride!", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            gfx.DrawString("Best regards,", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 15;

            gfx.DrawString("The Majorca TeslaRent Team", fontNormal, XBrushes.Black, new XPoint(margin, yPosition));
            yPosition += 20;

            var memoryStream = new MemoryStream();
            document.Save(memoryStream, false);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
