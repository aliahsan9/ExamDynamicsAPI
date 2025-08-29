using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.FeedbackDTOs
{
    public class FeedbackUpdateDto
    {
        [MaxLength(2000)]
        public string Response { get; set; } = string.Empty;

        public DateTime? RespondedAt { get; set; } = DateTime.UtcNow;
    }
}
