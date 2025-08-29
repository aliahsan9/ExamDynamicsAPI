using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs
{
    public class ExamMaterialUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string FileUrl { get; set; } = string.Empty;

        [Required]
        public int ExamId { get; set; }

        public int? UserId { get; set; }
    }
}
