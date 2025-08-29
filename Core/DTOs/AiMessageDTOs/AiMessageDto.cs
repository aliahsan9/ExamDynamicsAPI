namespace ExamDynamicsAPI.Core.DTOs.AiMessageDTOs
{
    public class AiMessageDto
    {
        public int AiMessageId { get; set; }
        public int AiSessionId { get; set; }
        public string Role { get; set; } = string.Empty; // User / AI
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}