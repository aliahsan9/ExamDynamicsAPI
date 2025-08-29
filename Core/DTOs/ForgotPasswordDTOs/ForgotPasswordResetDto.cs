namespace ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs
{
    public class ForgotPasswordResetDto
    {
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
