using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementReadDto>> GetAllAsync();
        Task<AnnouncementReadDto?> GetByIdAsync(int id);
        Task<AnnouncementReadDto> CreateAsync(AnnouncementCreateDto dto);
        Task<bool> UpdateAsync(int id, AnnouncementUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
