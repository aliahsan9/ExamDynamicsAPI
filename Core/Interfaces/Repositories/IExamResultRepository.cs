using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamResultRepository : IGenericRepository<ExamResult>
    {
        Task<IEnumerable<ExamResult>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ExamResult>> GetByExamIdAsync(int examId);
    }
}
