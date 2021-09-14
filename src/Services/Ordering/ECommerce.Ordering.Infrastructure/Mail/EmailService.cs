using System.Net;
using System.Threading.Tasks;
using ECommerce.Ordering.Application.Contracts.Infrastructure;
using ECommerce.Ordering.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce.Ordering.Infrastructure.Mail
{
    public class EmailService:IEmailService
    {
        public readonly EmailSettings _emailSettings;
        public readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation("Email sent");
            if (response.StatusCode==HttpStatusCode.Accepted || response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            _logger.LogError("Email sending failed");
            return false;
        }
    }
}