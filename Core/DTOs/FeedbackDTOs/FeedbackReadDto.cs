using System;

namespace ExamDynamicsAPI.Core.DTOs.FeedbackDTOs
{
    public class FeedbackReadDto
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public string? UserName { get; set; } // optional, from User entity

        public string Response { get; set; } = string.Empty;
        public DateTime? RespondedAt { get; set; }
    }
}
