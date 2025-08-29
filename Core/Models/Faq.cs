using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class Faq
    {
        [Key]
        public int FaqId { get; set; }

        [Required]
        public string Question { get; set; } = string.Empty;

        [Required]
        public string Answer { get; set; } = string.Empty;
    }
}