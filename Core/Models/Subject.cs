using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        // Foreign Key - Each Subject belongs to an Exam
        [Required]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        // Navigation Property - A Subject can have many Topics
        public ICollection<Topic>? Topics { get; set; }

        // Navigation Property - A Subject can have many Questions
        public ICollection<Question>? Questions { get; set; }

        // Navigation Property - A Subject can have many Study Materials
        public ICollection<StudyMaterial>? StudyMaterials { get; set; }
    }
}
