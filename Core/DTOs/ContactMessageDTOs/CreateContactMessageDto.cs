namespace ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs
{
    public class CreateContactMessageDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

}