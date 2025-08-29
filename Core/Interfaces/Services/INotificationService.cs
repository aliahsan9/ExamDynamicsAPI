using ExamDynamicsAPI.Core.DTOs.NotificationDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationReadDto>> GetAllAsync();
        Task<NotificationReadDto?> GetByIdAsync(int id);
        Task<IEnumerable<NotificationReadDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<NotificationReadDto>> GetUnreadByUserIdAsync(int userId);
        Task<NotificationReadDto> AddAsync(NotificationCreateDto notificationDto);
        Task<NotificationReadDto?> UpdateAsync(int id, NotificationUpdateDto notificationDto);
        Task<bool> DeleteAsync(int id);
    }
}