using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }

        public ICollection<Question>? Questions { get; set; } = new List<Question>();
        public ICollection<StudyMaterial>? StudyMaterials { get; set; } = new List<StudyMaterial>();
        public ICollection<UserProgress>? UserProgresses { get; set; } = new List<UserProgress>();
    }
}
