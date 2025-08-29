using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public ContactMessageRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactMessage>> GetAllAsync()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        public async Task<ContactMessage?> GetByIdAsync(int id)
        {
            return await _context.ContactMessages.FindAsync(id);
        }

        public async Task<ContactMessage> AddAsync(ContactMessage contactMessage)
        {
            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();
            return contactMessage;
        }

        public async Task<ContactMessage?> UpdateAsync(ContactMessage contactMessage)
        {
            var existing = await _context.ContactMessages.FindAsync(contactMessage.ContactMessageId);
            if (existing == null) return null;

            existing.Name = contactMessage.Name;
            existing.Email = contactMessage.Email;
            existing.Message = contactMessage.Message;
            existing.SentAt = contactMessage.SentAt;

            await _context.SaveChangesAsync();
            return existing; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.ContactMessages.FindAsync(id);
            if (existing == null) return false;

            _context.ContactMessages.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
