using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamMaterialRepository
    {
        Task<IEnumerable<ExamMaterial>> GetAllAsync();
        Task<ExamMaterial?> GetByIdAsync(int id);
        Task AddAsync(ExamMaterial entity);
        Task UpdateAsync(ExamMaterial entity);
        Task DeleteAsync(int id);
    }
}
