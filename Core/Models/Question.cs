using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        [Required]
        public string CorrectAnswer { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        // Optional: Foreign key to Exam
        public int? ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }

        // Relations
        public ICollection<Option>? Options { get; set; }

<<<<<<< HEAD
        // Add this for Answers
        public ICollection<Answer>? Answers { get; set; }
    }
}
 
=======
        // ✅ Add this for Answers
        public ICollection<Answer>? Answers { get; set; }
    }
}
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
