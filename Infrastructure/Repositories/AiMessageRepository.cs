using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class AiMessageRepository : GenericRepository<AiMessage>, IAiMessageRepository
    {
        public AiMessageRepository(ExamDynamicsDbContext context) : base(context) { }

        public async Task<IEnumerable<AiMessage>> GetMessagesByUserAsync(int userId)
        {
            return await _context.Set<AiMessage>()
                                 .Where(m => m.AiMessageId == userId)
                                 .AsNoTracking()
                                 .ToListAsync();
        } 

        public async Task<IEnumerable<AiMessage>> GetUnreadMessagesByUserAsync(int userId)
        {
            return await _context.Set<AiMessage>()
                                 .Where(m => m.UserId == userId && !m.IsRead)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
