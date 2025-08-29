using System;

namespace ExamDynamicsAPI.Core.Models
{
    public class ForgotPassword
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Reference to the user
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
 