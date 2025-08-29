using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ExamResultRepository : GenericRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExamResult>> GetByUserIdAsync(int userId)
        {
            return await _context.ExamResults
                                 .Where(er => er.UserId == userId)
                                 .Include(er => er.User)
                                 .Include(er => er.Exam)
                                 .AsNoTracking()
                                 .ToListAsync();
        } 

        public async Task<IEnumerable<ExamResult>> GetByExamIdAsync(int examId)
        {
            return await _context.ExamResults
                                 .Where(er => er.ExamId == examId)
                                 .Include(er => er.User)
                                 .Include(er => er.Exam)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
