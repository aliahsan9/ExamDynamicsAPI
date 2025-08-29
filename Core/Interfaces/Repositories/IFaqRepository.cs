using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IFaqRepository
    {
        Task<IEnumerable<Faq>> GetAllAsync();
        Task<Faq?> GetByIdAsync(int id);
        Task AddAsync(Faq faq);
        Task UpdateAsync(Faq faq);
        Task DeleteAsync(int id);
    }
}