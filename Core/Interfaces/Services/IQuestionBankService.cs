using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.QuestionBankDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IQuestionBankService
    {
        Task<IEnumerable<QuestionBankDto>> GetAllAsync();
        Task<QuestionBankDto?> GetByIdAsync(int id);
        Task<QuestionBankDto> CreateAsync(QuestionBankCreateDto dto);
        Task UpdateAsync(QuestionBankUpdateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<QuestionBankDto>> GetByTitleAsync(string title);
    }
}
