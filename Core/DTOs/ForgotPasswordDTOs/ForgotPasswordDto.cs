using System;

namespace ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs
{
    public class ForgotPasswordDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool IsUsed { get; set; }
    }
}
