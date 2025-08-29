using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        // Get all notifications for a specific user
        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int userId);

        // Get unread notifications for a user
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId);
    }
}
