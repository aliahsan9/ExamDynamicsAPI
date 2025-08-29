using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<Profile> GetByUserIdAsync(int userId);
        Task AddAsync(Profile profile);
        Task UpdateAsync(Profile profile);
        Task DeleteAsync(int id);
    }
}
