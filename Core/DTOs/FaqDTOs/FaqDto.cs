namespace ExamDynamicsAPI.Core.DTOs.FaqDTOs
{
    public class FaqDto
    {
        public int FaqId { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}