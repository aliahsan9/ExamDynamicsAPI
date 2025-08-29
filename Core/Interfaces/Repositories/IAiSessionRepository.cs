using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IAiSessionRepository
    {
        Task<IEnumerable<AiSession>> GetAllAsync();
        Task<AiSession?> GetByIdAsync(int id);
        Task<IEnumerable<AiSession>> GetByUserIdAsync(int userId);
        Task AddAsync(AiSession session);
        Task UpdateAsync(AiSession session);
        Task DeleteAsync(int id);
    }
}