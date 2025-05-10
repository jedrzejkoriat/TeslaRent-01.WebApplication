using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TeslaRent_01.WebApplication.Server.Services
{
    internal sealed class EmailSenderService : IEmailSender
    {
        private readonly string apiKey;
        private readonly string sendFromEmailAddress;

        public EmailSenderService(string apiKey, string sendFromEmailAddress)
        {
            this.apiKey = apiKey;
            this.sendFromEmailAddress = sendFromEmailAddress;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(apiKey);
            var sendFrom = new EmailAddress(sendFromEmailAddress);
            var sendTo = new EmailAddress(email);

            var message = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, "", htmlMessage);

            try
            {
                await client.SendEmailAsync(message);
            }
            catch
            {
                throw new Exception("Error while sending email.");
            }
        }
    }
}
