namespace ExamDynamicsAPI.Core.DTOs.ExamRegistrationDTOs
{
    public class ExamRegistrationDto
    {
        public int RegistrationId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
