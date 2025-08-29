namespace ExamDynamicsAPI.Core.DTOs.UserProfileDTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }              // User ID
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } // Optional
        public string? Bio { get; set; }         // Optional
        public string? ProfilePictureUrl { get; set; } // Optional
        public object? UserId { get; internal set; }
    }
}
