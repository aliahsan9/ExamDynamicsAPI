using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamDynamicsDbContext _dbContext;

        public QuestionRepository(ExamDynamicsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _dbContext.Questions.FindAsync(id);
        }

        public async Task<Question> AddAsync(Question question)
        {
            _dbContext.Questions.Add(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            _dbContext.Questions.Update(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _dbContext.Questions.FindAsync(id);
            if (question == null) return false;

            _dbContext.Questions.Remove(question);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
