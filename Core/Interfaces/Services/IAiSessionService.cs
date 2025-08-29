using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IAiSessionService
    {
        Task<IEnumerable<AiSession>> GetAllSessionsAsync();
        Task<AiSession?> GetSessionByIdAsync(int id);
        Task<IEnumerable<AiSession>> GetSessionsByUserIdAsync(int userId);
        Task AddSessionAsync(AiSession session);
        Task UpdateSessionAsync(AiSession session);
        Task DeleteSessionAsync(int id);
    }
}