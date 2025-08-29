using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ExamRegistrationRepository : IExamRegistrationRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public ExamRegistrationRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamRegistration>> GetAllAsync()
        {
            return await _context.ExamRegistrations.ToListAsync();
        }

        public async Task<ExamRegistration?> GetByIdAsync(int id)
        {
            return await _context.ExamRegistrations.FindAsync(id);
        }

        public async Task AddAsync(ExamRegistration entity)
        {
            await _context.ExamRegistrations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExamRegistration entity)
        {
            _context.ExamRegistrations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ExamRegistration entity)
        {
            _context.ExamRegistrations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamRegistration>> GetByUserIdAsync(int userId)
        {
            return await _context.ExamRegistrations
                                 .Where(x => x.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<ExamRegistration>> GetByExamIdAsync(int examId)
        {
            return await _context.ExamRegistrations
                                 .Where(x => x.ExamId == examId)
                                 .ToListAsync();
        }
    }
}
