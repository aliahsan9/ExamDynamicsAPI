using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Net;
using System.Net.Mail;

namespace ExamDynamicsAPI.Applications.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _repository;
        private readonly IConfiguration _configuration;

        public ContactMessageService(IContactMessageRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task SendMessageAsync(ContactMessageDto dto)
        {
            var visitorEmail = dto.ResolvedEmail;

            var contactMessage = new ContactMessage
            {
                UserEmail = visitorEmail,
                Message = dto.Message
            };

            await _repository.AddAsync(contactMessage);

            var smtpSection = _configuration.GetSection("SmtpSettings");
            string smtpServer = smtpSection["Server"] ?? string.Empty;

            int port = 0;
            if (!int.TryParse(smtpSection["Port"], out port))
                port = 587;

            string senderEmail = smtpSection["SenderEmail"] ?? string.Empty;
            string password = smtpSection["Password"] ?? string.Empty;
            string receiverEmail = smtpSection["ReceiverEmail"] ?? string.Empty;

            using var client = new SmtpClient(smtpServer, port);
            client.Credentials = new NetworkCredential(senderEmail, password);
            client.EnableSsl = true;

            var subject = string.IsNullOrWhiteSpace(visitorEmail)
                ? "New Contact Message from Website"
                : $"[Contact] {visitorEmail}";

            var body =
                $"Sender email: {visitorEmail}\r\n\r\nMessage:\r\n{dto.Message}";

            using var mailMessage = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            };

            if (!string.IsNullOrWhiteSpace(visitorEmail))
            {
                try
                {
                    mailMessage.ReplyToList.Add(new MailAddress(visitorEmail));
                }
                catch (FormatException)
                {
                    // Invalid address: body still contains the text they typed
                }
            }

            await client.SendMailAsync(mailMessage);
        }
    }
}
