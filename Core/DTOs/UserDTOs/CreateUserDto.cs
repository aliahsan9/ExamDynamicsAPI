namespace ExamDynamicsAPI.Core.DTOs.UserDTOs
{
 public class CreateUserDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

<<<<<<< HEAD
        public string Password { get; set; } = string.Empty;

=======
        // We take raw password from user, later hash it in service/repository
        public string Password { get; set; } = string.Empty;

        // Optional, defaults to "Student" if not provided
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
        public string Role { get; set; } = "Student";
    }

}