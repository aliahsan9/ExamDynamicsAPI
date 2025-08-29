namespace ExamDynamicsAPI.Core.DTOs.QuizDTOs
{
    public class QuizCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // You can add more fields if needed, e.g.:
        // public DateTime StartDate { get; set; }
        // public DateTime EndDate { get; set; }
        // public int DurationInMinutes { get; set; }
    }
}
