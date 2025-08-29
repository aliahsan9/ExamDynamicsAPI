using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IQuestionBankRepository : IGenericRepository<QuestionBank>
    {
        Task<IEnumerable<QuestionBank>> GetByTitleAsync(string title);
    }
}
