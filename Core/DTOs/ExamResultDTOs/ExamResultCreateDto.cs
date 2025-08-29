using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.ExamResultDTOs
{
    public class ExamResultCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ExamId { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int TotalMarks { get; set; }

        public string? Grade { get; set; }
    }
}
