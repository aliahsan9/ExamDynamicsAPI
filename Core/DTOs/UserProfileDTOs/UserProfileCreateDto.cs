using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.UserProfileDTOs
{
    public class UserProfileCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Bio { get; set; } = string.Empty;
    }
}
