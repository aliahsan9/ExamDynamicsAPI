using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.ExamResultDTOs
{
    public class ExamResultUpdateDto
    {
        [Required]
        public int Score { get; set; }

        [Required]
        public int TotalMarks { get; set; }

        public string? Grade { get; set; }
    }
}
