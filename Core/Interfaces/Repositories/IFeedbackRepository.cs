using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        // Get all feedbacks for a specific user
        Task<IEnumerable<Feedback>> GetFeedbacksByUserIdAsync(int userId);

        // Get a single feedback including the user
        Task<Feedback?> GetFeedbackWithUserAsync(int id);
    }
}
 