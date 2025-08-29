using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public ForgotPasswordRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ForgotPassword entity)
        {
            await _context.ForgotPasswords.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
         public async Task<ForgotPassword?> GetByTokenAsync(string token)
        {
            return await _context.ForgotPasswords.FirstOrDefaultAsync(f => f.Token == token);
        }

        public async Task UpdateAsync(ForgotPassword entity)
        {
            _context.ForgotPasswords.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ForgotPassword>> GetByUserIdAsync(int userId)
        {
            return await _context.ForgotPasswords.Where(f => f.UserId == userId).ToListAsync();
        }
    }
}
