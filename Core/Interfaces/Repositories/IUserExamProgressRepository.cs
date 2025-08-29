using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IUserExamProgressRepository
    {
        Task<IEnumerable<UserExamProgress>> GetAllAsync();
        Task<UserExamProgress?> GetByIdAsync(int id);
        Task<IEnumerable<UserExamProgress>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserExamProgress>> GetByExamIdAsync(int examId);
        Task AddAsync(UserExamProgress entity);
        Task UpdateAsync(UserExamProgress entity);
        Task DeleteAsync(int id);
    }
}
