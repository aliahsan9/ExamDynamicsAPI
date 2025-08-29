using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class QuestionBankRepository : GenericRepository<QuestionBank>, IQuestionBankRepository
    {

        public QuestionBankRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<QuestionBank>> GetByTitleAsync(string title)
        {
            return await _context.QuestionBanks
                                 .Where(qb => qb.Title.Contains(title))
                                 .AsNoTracking()
                                 .ToListAsync();
        }  
    }
}
