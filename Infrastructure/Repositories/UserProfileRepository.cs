using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public UserProfileRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<UserProfile?> GetByEmailAsync(string email)
        {
            return await _context.UserProfiles
                                 .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserProfile entity)
        {
            await _context.UserProfiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProfile entity)
        {
            _context.UserProfiles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UserProfiles.FindAsync(id);
            if (entity != null)
            {
                _context.UserProfiles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
