using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class Bookmark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookmarkId { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public string Url { get; set; } = null!;

        // Track when the bookmark was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ Foreign Key to User
        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        // Optional: link to Exam
        public int? ExamId { get; set; }
        public Exam? Exam { get; set; }

        // Optional: link to Question
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
