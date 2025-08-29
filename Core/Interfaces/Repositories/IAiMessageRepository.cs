using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IAiMessageRepository : IGenericRepository<AiMessage>
    {
        Task<IEnumerable<AiMessage>> GetMessagesByUserAsync(int userId);
        Task<IEnumerable<AiMessage>> GetUnreadMessagesByUserAsync(int userId);
    }
}
