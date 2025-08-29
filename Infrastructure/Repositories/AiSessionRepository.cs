using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class AiSessionRepository : IAiSessionRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public AiSessionRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        // Get all sessions
        public async Task<IEnumerable<AiSession>> GetAllAsync()
        {
            return await _context.AiSessions
                                 .Include(s => s.User)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Get session by ID
        public async Task<AiSession?> GetByIdAsync(int id)
        {
            return await _context.AiSessions
                                 .Include(s => s.User)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.UserId == id);
        }

        // Get all sessions for a specific user
        public async Task<IEnumerable<AiSession>> GetByUserIdAsync(int userId)
        {
            return await _context.AiSessions
                                 .Where(s => s.UserId == userId)
                                 .Include(s => s.User)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Add a new session
        public async Task AddAsync(AiSession session)
        {
            await _context.AiSessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        // Update an existing session
        public async Task UpdateAsync(AiSession session)
        {
            _context.AiSessions.Update(session);
            await _context.SaveChangesAsync();
        }

        // Delete session by ID
        public async Task DeleteAsync(int id)
        {
            var session = await _context.AiSessions.FindAsync(id);
            if (session != null)
            {
                _context.AiSessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
