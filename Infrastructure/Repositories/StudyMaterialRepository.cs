using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class StudyMaterialRepository : IStudyMaterialRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public StudyMaterialRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        // Get all study materials
        public async Task<IEnumerable<StudyMaterial>> GetAllAsync()
        {
            return await _context.StudyMaterials
                                 .Include(m => m.Topic)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Get a study material by its Id
        public async Task<StudyMaterial?> GetByIdAsync(int id)
        {
            return await _context.StudyMaterials
                                 .Include(m => m.Topic)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        // Get study materials by TopicId 
        public async Task<IEnumerable<StudyMaterial>> GetByTopicIdAsync(int topicId)
        {
            return await _context.StudyMaterials
                                 .Where(m => m.TopicId == topicId)
                                 .Include(m => m.Topic)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Add a new study material
        public async Task AddAsync(StudyMaterial material)
        {
            await _context.StudyMaterials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        // Update an existing study material
        public async Task UpdateAsync(StudyMaterial material)
        {
            _context.StudyMaterials.Update(material);
            await _context.SaveChangesAsync();
        }

        // Delete a study material by Id
        public async Task DeleteAsync(int id)
        {
            var material = await _context.StudyMaterials.FindAsync(id);
            if (material != null)
            {
                _context.StudyMaterials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }
    }
}
