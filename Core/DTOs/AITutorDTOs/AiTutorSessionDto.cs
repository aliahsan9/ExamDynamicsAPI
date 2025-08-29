namespace ExamDynamicsAPI.Core.DTOs.AITutorDTOs
{
 public class AiSessionDto
    {
        public int AiSessionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartedAt { get; set; }
    }
}