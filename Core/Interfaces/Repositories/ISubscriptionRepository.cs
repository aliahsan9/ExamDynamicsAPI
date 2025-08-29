using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(int id);
        Task AddAsync(Subscription entity);
        Task UpdateAsync(Subscription entity);
        Task DeleteAsync(int id);

        Task<IEnumerable<Subscription>> GetByUserIdAsync(int userId);
    }
}
