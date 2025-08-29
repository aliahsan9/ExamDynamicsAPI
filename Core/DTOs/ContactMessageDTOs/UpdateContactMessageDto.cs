namespace ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs
{
    public class UpdateContactMessageDto
    {
        public string Name { get; set; } = string.Empty;   // ✅ Added Name property
        public string Message { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
