namespace ExamDynamicsAPI.Models
{
    public class ChatMessage
    {
        public string Role { get; set; } = "user"; // user or assistant
        public string Content { get; set; } = string.Empty;
    }
}
 