using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface ISettingRepository
    {
        Task<IEnumerable<Setting>> GetAllAsync();
        Task<Setting?> GetByIdAsync(int id);
        Task AddAsync(Setting entity);
        Task UpdateAsync(Setting entity);
        Task DeleteAsync(int id);
    }
}
