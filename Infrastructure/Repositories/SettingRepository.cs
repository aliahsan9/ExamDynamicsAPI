using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly ExamDynamicsDbContext _context;
        public SettingRepository(ExamDynamicsDbContext context) => _context = context;

        public async Task<IEnumerable<Setting>> GetAllAsync() => await _context.Settings.ToListAsync();

        public async Task<Setting?> GetByIdAsync(int id) => await _context.Settings.FindAsync(id);

        public async Task AddAsync(Setting entity)
        {
            await _context.Settings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Setting entity)
        {
            _context.Settings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e != null)
            {
                _context.Settings.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}
