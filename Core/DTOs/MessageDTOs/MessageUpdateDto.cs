namespace ExamDynamicsAPI.Core.DTOs.MessageDTOs
{
    public class MessageUpdateDto
    {
        public string? Content { get; set; } // optional update
        public bool? IsRead { get; set; }
    }
}
