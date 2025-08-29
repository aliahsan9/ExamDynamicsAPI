using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        // ================= GET BY USER ID =================
        public async Task<IEnumerable<Subscription>> GetByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                                 .Where(s => s.UserId == userId)
                                 .ToListAsync();
        }
    }
}
