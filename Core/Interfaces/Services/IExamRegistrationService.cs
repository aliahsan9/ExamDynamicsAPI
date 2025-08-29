using ExamDynamicsAPI.Core.DTOs.ExamRegistrationDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IExamRegistrationService 
    {
        Task<IEnumerable<ExamRegistrationDto>> GetAllAsync();
        Task<ExamRegistrationDto?> GetByIdAsync(int id);
        Task<ExamRegistrationDto> RegisterAsync(ExamRegistrationCreateDto dto);
        Task<bool> UpdateAsync(int id, ExamRegistrationUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ExamRegistrationDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ExamRegistrationDto>> GetByExamIdAsync(int examId);
    }
}
