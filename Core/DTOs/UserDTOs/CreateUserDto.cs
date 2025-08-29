namespace ExamDynamicsAPI.Core.DTOs.UserDTOs
{
 public class CreateUserDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // We take raw password from user, later hash it in service/repository
        public string Password { get; set; } = string.Empty;

        // Optional, defaults to "Student" if not provided
        public string Role { get; set; } = "Student";
    }

}