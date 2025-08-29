using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class AiMessage
    {
        [Key]
        public int AiMessageId { get; set; }

        [Required] 
        public string Content { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Sender { get; set; } = string.Empty; // "User" or "AI"

        [ForeignKey("AiSession")]
        public int AiSessionId { get; set; }
        public AiSession? AiSession { get; set; }

        // Added properties
        public int UserId { get; set; } // For filtering messages by user
        public bool IsRead { get; set; } = false; // To mark messages as read/unread

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
