using ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IExamMaterialService
    {
        Task<IEnumerable<ExamMaterialReadDto>> GetAllAsync();
        Task<ExamMaterialReadDto?> GetByIdAsync(int id);
        Task<ExamMaterialReadDto> CreateAsync(ExamMaterialCreateDto dto);
        Task UpdateAsync(int id, ExamMaterialUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
