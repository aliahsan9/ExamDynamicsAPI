using ExamDynamicsAPI.Core.Models;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
 public interface IUserProfileRepository : IGenericRepository<UserProfile>    {
        // Custom repository methods
        Task<UserProfile?> GetByEmailAsync(string email);
    }
}
 