using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class ContactMessage
    {
        [Key]
        public int ContactMessageId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Message { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;


    // You probably want to link it with User
    public int? UserId { get; set; }   // FK
    public ApplicationUser? User { get; set; }       // Navigation
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
