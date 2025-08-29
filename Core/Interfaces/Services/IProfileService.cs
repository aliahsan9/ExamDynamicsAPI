using ExamDynamicsAPI.Core.DTOs.ProfileDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services

{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfileByUserIdAsync(int userId);
        Task CreateProfileAsync(ProfileDto profileDto);
        Task UpdateProfileAsync(ProfileDto profileDto);
        Task DeleteProfileAsync(int id);
    }
}
