using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        // Get payments made by a specific user
        public async Task<IEnumerable<Payment>> GetByUserIdAsync(int userId)
        {
            return await _context.Payments
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        // Get all successful payments
        public async Task<IEnumerable<Payment>> GetSuccessfulPaymentsAsync()
        {
            return await _context.Payments
                .Where(p => p.Status == "Success") // Assuming Status property indicates success
                .ToListAsync();
        }
    }
}
