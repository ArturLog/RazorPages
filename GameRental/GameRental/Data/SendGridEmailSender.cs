using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace GameRental.Data
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly string _apiKey;

        public SendGridEmailSender(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("artur.spiewak2967@gmail.com", "ATP");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            return client.SendEmailAsync(msg);
        }
    }
}
