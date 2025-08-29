using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;

namespace ExamDynamicsAPI.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)] 
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional: For which user the notification is
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        // Optional: Notification type (e.g., Info, Alert)
        [MaxLength(50)]
        public string Type { get; set; } = "Info";

        // Optional: Reference to related entity (like Exam, Feedback, etc.)
        public int? ReferenceId { get; set; }
        [MaxLength(100)]
        public string? ReferenceType { get; set; }
    }
}
