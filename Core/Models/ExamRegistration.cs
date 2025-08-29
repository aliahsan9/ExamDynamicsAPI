using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class ExamRegistration
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required]
        public int UserId { get; set; }  // FK to User

        [Required]
        public int ExamId { get; set; }  // FK to Exam

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // Relations
// You probably want to link it with User
    public ApplicationUser? User { get; set; }       // Navigation
        public ApplicationUser? ApplicationUser { get; set; }        public Exam? Exam { get; set; }   // ✅ Corrected: linked to Exam entity
    }
}
