using ExamDynamicsAPI.Core.DTOs.AnswerDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IAnswerService
    {
        // Include userId (int) to avoid foreign key issues
        Task<AnswerReadDto> CreateAsync(AnswerCreateDto dto, int userId);

        Task<AnswerReadDto?> GetByIdAsync(int id);

        Task<IEnumerable<AnswerReadDto>> GetAllAsync();

        Task<bool> UpdateAsync(int id, AnswerUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
