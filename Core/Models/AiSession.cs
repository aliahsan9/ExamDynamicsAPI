using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class AiSession
    {
        [Key]
        public int AiSessionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }

        public ICollection<AiMessage>? Messages { get; set; }
    }
}