using System.Net;
using System.Net.Mail;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using Microsoft.Extensions.Options;

namespace ExamDynamicsAPI.Applications.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings, ILogger<EmailService> logger)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings), "Email settings are not configured.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                // Validate required settings
                if (string.IsNullOrWhiteSpace(_settings.SmtpServer))
                {
                    _logger.LogWarning("Email skipped: SMTP server is not configured.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_settings.SenderEmail))
                {
                    _logger.LogError("Email sending failed: SenderEmail is not configured.");
                    throw new InvalidOperationException("SenderEmail cannot be empty.");
                }

                if (string.IsNullOrWhiteSpace(_settings.Username) || string.IsNullOrWhiteSpace(_settings.Password))
                {
                    _logger.LogError("Email sending failed: SMTP credentials are not configured.");
                    throw new InvalidOperationException("SMTP username or password cannot be empty.");
                }

                // Create SMTP client
                using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
                {
                    Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                    EnableSsl = _settings.EnableSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                // Create email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_settings.SenderEmail, _settings.SenderName ?? "ExamDynamics"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                // Send email asynchronously
                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email successfully sent to {Recipient}", to);
            }
            catch (SmtpException smtpEx)
            {
                _logger.LogError(smtpEx, "SMTP error occurred while sending email to {Recipient}: {Message}", to, smtpEx.Message);
                throw; // optionally rethrow or handle gracefully
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while sending email to {Recipient}: {Message}", to, ex.Message);
                throw;
            }
        }
    }
}