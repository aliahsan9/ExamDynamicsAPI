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
    var contactMessage = new ContactMessage
    {
        UserEmail = dto.UserEmail,
        Message = dto.Message
    };

    // Save to DB
    await _repository.AddAsync(contactMessage);

    // Read SMTP settings safely
    var smtpSection = _configuration.GetSection("SmtpSettings");
    string smtpServer = smtpSection["Server"] ?? string.Empty;

    int port = 0;
    if (!int.TryParse(smtpSection["Port"], out port))
        port = 587; // default port

    string senderEmail = smtpSection["SenderEmail"] ?? string.Empty;
    string password = smtpSection["Password"] ?? string.Empty;
    string receiverEmail = smtpSection["ReceiverEmail"] ?? string.Empty;

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
