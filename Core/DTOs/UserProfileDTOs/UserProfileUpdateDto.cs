using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.UserProfileDTOs
{
    public class UserProfileUpdateDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(1000)]
        public string? Bio { get; set; }
    }
}
