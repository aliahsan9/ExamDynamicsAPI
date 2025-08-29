using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IProgressRepository
    {
        Task<Progress<int>> GetProgressAsync(int userId);
        Task UpdateProgressAsync(int userId, int value);
    }
}
