using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.QuestionBankDTOs
{
    public class QuestionBankUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
