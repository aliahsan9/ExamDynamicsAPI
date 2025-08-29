using System.Collections.Generic;
using System.Threading.Tasks;
using ExamDynamicsAPI.Core.DTOs.QuizDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizDto>> GetAllQuizzesAsync();
        Task<QuizDto?> GetQuizByIdAsync(int id);
        Task<QuizDto> CreateQuizAsync(QuizCreateDto createDto);
        Task<QuizDto?> UpdateQuizAsync(int id, QuizUpdateDto updateDto);
        Task<bool> DeleteQuizAsync(int id);
    }
}
