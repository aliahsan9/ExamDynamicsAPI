using ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IStudyMaterialService
    {
        Task<IEnumerable<StudyMaterialDto>> GetAllAsync();
        Task<StudyMaterialDto?> GetByIdAsync(int id);
        Task<StudyMaterialDto> CreateAsync(CreateStudyMaterialDto createDto);
        Task<StudyMaterialDto?> UpdateAsync(int id, UpdateStudyMaterialDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
