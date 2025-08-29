using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task<Message> AddAsync(Message entity);
        Task<Message?> UpdateAsync(Message entity);
        Task<bool> DeleteAsync(int id);

        // Extra useful methods
        Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId);
        Task<IEnumerable<Message>> GetUnreadMessagesByUserAsync(int userId);
    }
}
