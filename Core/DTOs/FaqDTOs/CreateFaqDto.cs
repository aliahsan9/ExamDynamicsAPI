namespace ExamDynamicsAPI.Core.DTOs.FaqDTOs
{
    public class CreateFaqDto
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}