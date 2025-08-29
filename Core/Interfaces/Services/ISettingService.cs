using ExamDynamicsAPI.Core.DTOs.settingDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface ISettingService
    {
        Task<IEnumerable<SettingDto>> GetAllAsync();
        Task<SettingDto?> GetByIdAsync(int id);
        Task<SettingDto> CreateAsync(CreateSettingDto dto);
        Task<SettingDto?> UpdateAsync(UpdateSettingDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
