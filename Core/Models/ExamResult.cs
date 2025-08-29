using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;
using static ExamDynamicsAPI.Core.Models.BlogPost;

namespace ExamDynamicsAPI.Core.Models
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }

        // Foreign Keys
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }

        // Result Details
        [Required]
        public int Score { get; set; }

        [Required]
        public int TotalMarks { get; set; }

        public DateTime TakenAt { get; set; } = DateTime.UtcNow;

        public string? Grade { get; set; }
    }
}
 