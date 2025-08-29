using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class UserExamProgressRepository : IUserExamProgressRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public UserExamProgressRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserExamProgress>> GetAllAsync()
        {
            return await _context.UserExamProgresses.ToListAsync();
        }

        public async Task<UserExamProgress?> GetByIdAsync(int id)
        {
            return await _context.UserExamProgresses.FindAsync(id);
        }

        public async Task<IEnumerable<UserExamProgress>> GetByUserIdAsync(int userId)
        {
            return await _context.UserExamProgresses
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserExamProgress>> GetByExamIdAsync(int examId)
        {
            return await _context.UserExamProgresses
                .AsNoTracking()
                .Where(x => x.ExamId == examId)
                .ToListAsync();
        }

        public async Task AddAsync(UserExamProgress entity)
        {
            await _context.UserExamProgresses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserExamProgress entity)
        {
            _context.UserExamProgresses.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UserExamProgresses.FindAsync(id);
            if (entity != null)
            {
                _context.UserExamProgresses.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
 