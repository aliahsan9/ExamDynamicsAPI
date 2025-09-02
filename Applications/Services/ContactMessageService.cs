// Services/ContactMessageService.cs
using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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
            var contactMessage = new ContactMessage
            {
                UserEmail = dto.UserEmail,
                Message = dto.Message
            };

            // Save to DB
            await _repository.AddAsync(contactMessage);

            // Send Email
            var smtpSection = _configuration.GetSection("SmtpSettings");
            string smtpServer = smtpSection["Server"];
            int port = int.Parse(smtpSection["Port"]);
            string senderEmail = smtpSection["SenderEmail"];
            string password = smtpSection["Password"];
            string receiverEmail = smtpSection["ReceiverEmail"]; // Your website email

            using (var client = new SmtpClient(smtpServer, port))
            {
                client.Credentials = new NetworkCredential(senderEmail, password);
                client.EnableSsl = true;

                var mailMessage = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "New Contact Message from Website",
                    Body = $"From: {dto.UserEmail}\n\nMessage:\n{dto.Message}"
                };

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
