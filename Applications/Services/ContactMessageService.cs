using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services

{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _repository;

        public ContactMessageService(IContactMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContactMessageDto>> GetAllAsync()
        {
            var messages = await _repository.GetAllAsync();
            return messages.Select(m => new ContactMessageDto
            {
                ContactMessageId = m.ContactMessageId,
                Name = m.Name,
                Email = m.Email,
                Message = m.Message,
                SentAt = m.SentAt
            });
        }

        public async Task<ContactMessageDto?> GetByIdAsync(int id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null) return null;

            return new ContactMessageDto
            { 
                ContactMessageId = message.ContactMessageId,
                Name = message.Name,
                Email = message.Email,
                Message = message.Message,
                SentAt = message.SentAt 
            };
        }

        public async Task<ContactMessageDto> AddAsync(CreateContactMessageDto createDto)
        {
            var model = new ContactMessage
            {
                Name = createDto.Name,
                Email = createDto.Email,
                Message = createDto.Message,
                SentAt = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(model);

            return new ContactMessageDto
            {
                ContactMessageId = created.ContactMessageId,
                Name = created.Name,
                Email = created.Email,
                Message = created.Message,
                SentAt = created.SentAt
            };
        }
  
        public async Task<ContactMessageDto?> UpdateAsync(int id, UpdateContactMessageDto updateDto)
        {
            var model = new ContactMessage
            {
                ContactMessageId = id,
                Name = updateDto.Name,
                Email = updateDto.Email,
                Message = updateDto.Message,
                SentAt = DateTime.UtcNow
            };

            var updated = await _repository.UpdateAsync(model);
            if (updated == null) return null;

            return new ContactMessageDto
            {
                ContactMessageId = updated.ContactMessageId,
                Name = updated.Name,
                Email = updated.Email,
                Message = updated.Message,
                SentAt = updated.SentAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
