using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public MessageRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _context.Messages
                                 .Include(m => m.Sender)
                                 .Include(m => m.Receiver)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages
                                 .Include(m => m.Sender)
                                 .Include(m => m.Receiver)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Message> AddAsync(Message entity)
        {
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Message?> UpdateAsync(Message entity)
        {
            var existing = await _context.Messages.FindAsync(entity.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Messages.FindAsync(id);
            if (entity == null) return false;

            _context.Messages.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId)
        {
            return await _context.Messages
                                 .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                                 .Include(m => m.Sender)
                                 .Include(m => m.Receiver)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetUnreadMessagesByUserAsync(int userId)
        {
            return await _context.Messages
                                 .Where(m => m.ReceiverId == userId && !m.IsRead)
                                 .Include(m => m.Sender)
                                 .Include(m => m.Receiver)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
