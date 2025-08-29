namespace ExamDynamicsAPI.Core.DTOs.AiMessageDTOs
{
    public class CreateAiMessageDto
    {
        public int AiSessionId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}