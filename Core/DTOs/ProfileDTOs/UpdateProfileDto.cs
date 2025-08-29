namespace ExamDynamicsAPI.Core.DTOs.ProfileDTOs
{
    public class UpdateProfileDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}