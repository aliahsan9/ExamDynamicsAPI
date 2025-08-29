using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamRegistrationRepository
    {
        Task<IEnumerable<ExamRegistration>> GetAllAsync();
        Task<ExamRegistration?> GetByIdAsync(int id);
        Task AddAsync(ExamRegistration entity);
        Task UpdateAsync(ExamRegistration entity);
        Task DeleteAsync(ExamRegistration entity);
        Task<IEnumerable<ExamRegistration>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ExamRegistration>> GetByExamIdAsync(int examId);
    }
}
