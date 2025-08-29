using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; } 

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relations
        // Exam can have multiple subjects
public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        // Exam registrations
        public ICollection<ExamRegistration>? ExamRegistrations { get; set; }

        // Exam results
        public ICollection<ExamResult>? ExamResults { get; set; }

    }
}
