using ExamDynamicsAPI.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IForgotPasswordRepository
    {
        Task AddAsync(ForgotPassword entity);
        Task<ForgotPassword?> GetByTokenAsync(string token);
        Task UpdateAsync(ForgotPassword entity);
        Task<IEnumerable<ForgotPassword>> GetByUserIdAsync(int userId);
    }
}
