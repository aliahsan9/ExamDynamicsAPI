using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IOptionRepository
    {
        Task<IEnumerable<Option>> GetAllAsync();
        Task<Option?> GetByIdAsync(int id);
        Task AddAsync(Option option);
        Task UpdateAsync(Option option);
        Task DeleteAsync(Option option);
        Task<IEnumerable<Option>> GetByQuestionIdAsync(int questionId);
    }
}
