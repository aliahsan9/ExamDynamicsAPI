using ExamDynamicsAPI.Core.DTOs.PaymentDTOs;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        // Get all payments
        Task<IEnumerable<PaymentDto>> GetAllAsync();

        // Get payment by ID
        Task<PaymentDto?> GetByIdAsync(int id);

        // Get payments by user ID
        Task<IEnumerable<PaymentDto>> GetByUserIdAsync(int userId);

        // Get all successful payments
        Task<IEnumerable<PaymentDto>> GetSuccessfulPaymentsAsync();

        // Create a new payment
        Task<PaymentDto> CreateAsync(CreatePaymentDto createDto);

        // Update existing payment
        Task<bool> UpdateAsync(int id, UpdatePaymentDto updateDto);

        // Delete payment
        Task<bool> DeleteAsync(int id);
    }
}
