using ExamDynamicsAPI.Core.DTOs.ProgressDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services

{
    public interface IProgressService
    {
        Task<IEnumerable<ProgressDto>> GetProgressByUserAsync(int userId);
        Task AddProgressAsync(ProgressDto progressDto);
        Task UpdateProgressAsync(ProgressDto progressDto);
    }
}
