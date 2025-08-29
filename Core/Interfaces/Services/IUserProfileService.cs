using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileDto>> GetAllAsync();
        Task<UserProfileDto?> GetByIdAsync(int userId);
        Task<UserProfileDto> CreateAsync(UserProfileCreateDto createDto);
        Task<bool> UpdateAsync(int userId, UserProfileUpdateDto updateDto);
        Task<bool> DeleteAsync(int userId);
        Task<UserProfileDto?> GetByEmailAsync(string email);
    }
}
 