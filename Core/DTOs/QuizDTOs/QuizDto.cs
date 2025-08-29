namespace ExamDynamicsAPI.Core.DTOs.QuizDTOs
{
    public class QuizDto
    {
        public int Id { get; set; }   // Quiz Id
        public string Title { get; set; } = string.Empty;   // Quiz Title
        public string Description { get; set; } = string.Empty;   // Quiz Description
        public int TotalQuestions { get; set; }   // Number of questions in quiz
        public int TimeLimit { get; set; }   // Time limit in minutes
        public DateTime CreatedAt { get; set; }   // Date created
    }
}
