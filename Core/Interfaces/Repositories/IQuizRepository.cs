using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(int id);
        Task<Quiz> AddAsync(Quiz quiz);     // return Quiz instead of void
        Task<Quiz?> UpdateAsync(Quiz quiz); // return Quiz instead of void
        Task<bool> DeleteAsync(int id);
    }
}
