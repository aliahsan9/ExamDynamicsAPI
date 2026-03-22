using ExamDynamicsAPI.Core.DTOs.AnswerDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IAnswerService
    {
<<<<<<< HEAD
=======
        // Include userId (int) to avoid foreign key issues
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
        Task<AnswerReadDto> CreateAsync(AnswerCreateDto dto, int userId);

        Task<AnswerReadDto?> GetByIdAsync(int id);

        Task<IEnumerable<AnswerReadDto>> GetAllAsync();

        Task<bool> UpdateAsync(int id, AnswerUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
