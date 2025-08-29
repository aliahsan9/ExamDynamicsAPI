using System.ComponentModel.DataAnnotations;
using static ExamDynamicsAPI.Core.Models.Answer;

namespace ExamDynamicsAPI.Core.Models
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }

        [Required]
        public int UserId { get; set; }  // FK to User

        [Required]
        public int ExamId { get; set; }  // FK to Exam

        [Range(0, 100)]
        public int Percentage { get; set; } = 0;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        // Relations
        public ApplicationUser? User { get; set; }
        public Exam? Exam { get; set; }
    }
}
