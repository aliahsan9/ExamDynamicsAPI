using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;
using static ExamDynamicsAPI.Core.Models.BlogPost;

namespace ExamDynamicsAPI.Core.Models
{
    public class ExamMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string FileUrl { get; set; } = string.Empty; // link to PDF, doc, etc.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key to Exam
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }

        // Optional: uploaded by user
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
