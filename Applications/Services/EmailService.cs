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
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(_settings.SmtpServer))
            {
                _logger.LogWarning("Email skipped: SMTP server is not configured.");
                return;
            }

            using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSSL
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            await client.SendMailAsync(mailMessage);
        }
    }
}