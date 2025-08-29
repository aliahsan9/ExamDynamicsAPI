using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IUserExamProgressService
    {
        Task<IEnumerable<UserExamProgressReadDto>> GetAllAsync();
        Task<UserExamProgressReadDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserExamProgressReadDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserExamProgressReadDto>> GetByExamIdAsync(int examId);
        Task<UserExamProgressReadDto> CreateAsync(UserExamProgressCreateDto createDto);
        Task<bool> UpdateAsync(int id, UserExamProgressUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
