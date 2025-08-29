using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;

namespace ExamDynamicsAPI.Core.Models
{
     public class Result
    {
        [Key]
        public int ResultId { get; set; }

        public int Score { get; set; }
        public DateTime TakenAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}