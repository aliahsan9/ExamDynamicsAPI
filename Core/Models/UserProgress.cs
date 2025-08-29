using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;
using static ExamDynamicsAPI.Core.Models.BlogPost;

namespace ExamDynamicsAPI.Core.Models
{
    public class UserProgress
    {
        [Key]
        public int UserProgressId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public int TopicId { get; set; }

        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; } = null!;

        [Range(0, 100)]
        public int ProgressPercent { get; set; } = 0;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
