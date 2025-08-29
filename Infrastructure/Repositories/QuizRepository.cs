using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using ExamDynamicsAPI.Core.Interfaces.Repositories;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public QuizRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Questions) // eager load if needed
                .ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Quiz> AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz?> UpdateAsync(Quiz quiz)
        {
            var existingQuiz = await _context.Quizzes.FindAsync(quiz.Id);
            if (existingQuiz == null) return null;

            _context.Entry(existingQuiz).CurrentValues.SetValues(quiz);
            await _context.SaveChangesAsync();

            return existingQuiz;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null) return false;

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
