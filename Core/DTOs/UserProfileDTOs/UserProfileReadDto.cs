namespace ExamDynamicsAPI.Core.DTOs.UserProfileDTOs
{
    public class UserProfileReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}
