using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IPaymentRepository  
    {
         Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment entity);
        Task UpdateAsync(Payment entity);
        Task DeleteAsync(int id);

        // Extra useful methods
        Task<IEnumerable<Payment>> GetByUserIdAsync(int userId); // payments made by a user
        Task<IEnumerable<Payment>> GetSuccessfulPaymentsAsync();  // all successful payments
    }
}
