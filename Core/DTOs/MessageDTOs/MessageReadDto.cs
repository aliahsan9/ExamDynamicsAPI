namespace ExamDynamicsAPI.Core.DTOs.MessageDTOs
{
    public class MessageReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        public int SenderId { get; set; }
        public string? SenderName { get; set; }

        public int ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
    }
}
