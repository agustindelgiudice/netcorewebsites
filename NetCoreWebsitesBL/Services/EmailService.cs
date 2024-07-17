using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreWebsitesBL.Configurations;
using NetCoreWebsitesBL.Helpers;

namespace NetCoreWebsitesBL.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpSettings> smtpSettings, ILogger<EmailService> logger)
        {
            _smtpSettings = smtpSettings.Value ?? throw new ArgumentNullException(nameof(smtpSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            if (!EmailValidator.IsValidEmail(toEmail))
            {
                _logger.LogWarning("Invalid email format: {Email}", toEmail);
                throw new FormatException("The specified string is not in the form required for an e-mail address.");
            }

            using (var smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Host,
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl
            })
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                try
                {
                    _logger.LogInformation("Attempting to send email to {Email}", toEmail);
                    await smtpClient.SendMailAsync(mailMessage).ConfigureAwait(false);
                    _logger.LogInformation("Email successfully sent to {Email}", toEmail);
                }
                catch (SmtpException smtpEx)
                {
                    _logger.LogError(smtpEx, "SMTP error occurred while sending email to {Email}", toEmail);
                    throw new InvalidOperationException("An SMTP error occurred while sending the email.", smtpEx);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while sending email to {Email}", toEmail);
                    throw new InvalidOperationException("An error occurred while sending the email.", ex);
                }
            }
        }
    }
}
