namespace ExamDynamicsAPI.Core.DTOs.QuizDTOs
{
    public class QuizReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int QuestionCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
