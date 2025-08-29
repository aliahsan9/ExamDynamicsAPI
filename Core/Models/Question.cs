using System;
using System.Collections.Generic;
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

        // Foreign key to Topic
        [Required]
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic? Topic { get; set; }

        // Optional: Foreign key to Exam
        public int? ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }

        // Relations
        public ICollection<Option>? Options { get; set; }
        public ICollection<Bookmark>? Bookmarks { get; set; }

        // ✅ Add this for Answers
        public ICollection<Answer>? Answers { get; set; }
    }
}
