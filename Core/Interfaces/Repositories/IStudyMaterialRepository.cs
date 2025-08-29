using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IStudyMaterialRepository
    {
        Task<IEnumerable<StudyMaterial>> GetAllAsync();
        Task<StudyMaterial?> GetByIdAsync(int id);
        Task<IEnumerable<StudyMaterial>> GetByTopicIdAsync(int topicId);
        Task AddAsync(StudyMaterial material);
        Task UpdateAsync(StudyMaterial material);
        Task DeleteAsync(int id);
    }
}