using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ExamDynamicsAPI.Core.Models
{
    public class QuestionBank
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Relations
        public ICollection<Question>? Questions { get; set; }
    }
}
