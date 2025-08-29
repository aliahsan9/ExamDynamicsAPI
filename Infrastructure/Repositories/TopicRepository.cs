using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public TopicRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            return await _context.Topics.Include(t => t.Subject).ToListAsync();
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _context.Topics
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Topic>> GetBySubjectIdAsync(int subjectId)
        {
            return await _context.Topics
                .Where(t => t.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Topic topic)
        {
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }
    }
}