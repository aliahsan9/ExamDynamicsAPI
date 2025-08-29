namespace ExamDynamicsAPI.Core.DTOs.ProfileDTOs
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}