using ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IForgotPasswordService
    {
        Task<ForgotPasswordDto> GenerateTokenAsync(ForgotPasswordCreateDto dto);
        Task<bool> ResetPasswordAsync(ForgotPasswordResetDto dto);
        Task<IEnumerable<ForgotPasswordDto>> GetByUserIdAsync(int userId);
    }
}
