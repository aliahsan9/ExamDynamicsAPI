using ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAllAsync();
        Task<SubscriptionDto?> GetByIdAsync(int id);
        Task<SubscriptionDto> CreateAsync(SubscriptionCreateDto createDto);
        Task<bool> UpdateAsync(int id, SubscriptionUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<SubscriptionDto>> GetByUserIdAsync(int userId);
    }
}
