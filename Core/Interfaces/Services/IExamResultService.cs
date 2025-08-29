using ExamDynamicsAPI.Core.DTOs.ExamResultDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IExamResultService
    {
        // Get all exam results
        Task<IEnumerable<ExamResultDto>> GetAllAsync();

        // Get exam result by ID
        Task<ExamResultDto?> GetByIdAsync(int id);

        // Get results by user ID
        Task<IEnumerable<ExamResultDto>> GetByUserIdAsync(int userId);

        // Get results by exam ID
        Task<IEnumerable<ExamResultDto>> GetByExamIdAsync(int examId);

        // Create a new exam result
        Task<ExamResultDto> CreateAsync(ExamResultCreateDto createDto);

        // Update an existing exam result
        Task<bool> UpdateAsync(int id, ExamResultUpdateDto updateDto);

        // Delete an exam result
        Task<bool> DeleteAsync(int id);
    }
}
