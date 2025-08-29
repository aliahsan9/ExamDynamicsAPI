using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {

        public NotificationRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int userId)
        {
            return await _context.Notifications
                                 .Where(n => n.UserId == userId)
                                 .Include(n => n.User)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await _context.Notifications
                                 .Where(n => n.UserId == userId && !n.IsRead)
                                 .Include(n => n.User)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
