using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ExamMaterialRepository : IExamMaterialRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public ExamMaterialRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        // GET ALL 
        public async Task<IEnumerable<ExamMaterial>> GetAllAsync()
        {
            return await _context.ExamMaterials
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // GET BY ID
        public async Task<ExamMaterial?> GetByIdAsync(int id)
        {
            return await _context.ExamMaterials.FindAsync(id);
        }

        // ADD
        public async Task AddAsync(ExamMaterial entity)
        {
            await _context.ExamMaterials.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(ExamMaterial entity)
        {
            _context.ExamMaterials.Update(entity);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.ExamMaterials.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
