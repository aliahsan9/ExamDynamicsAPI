using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IContactMessageRepository
    {
        Task<IEnumerable<ContactMessage>> GetAllAsync();
        Task<ContactMessage?> GetByIdAsync(int id);
        Task<ContactMessage> AddAsync(ContactMessage contactMessage);
        Task<ContactMessage?> UpdateAsync(ContactMessage contactMessage);
        Task<bool> DeleteAsync(int id);
    }
}
