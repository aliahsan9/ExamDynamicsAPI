using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.FeedbackDTOs
{
    public class FeedbackCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;

        // Optional: allow user to send their user ID if not from authentication
        public int UserId { get; set; }
    }
}
