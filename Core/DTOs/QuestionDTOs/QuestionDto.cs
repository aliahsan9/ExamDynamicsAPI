namespace ExamDynamicsAPI.Core.DTOs.QuestionDTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string? Explanation { get; set; }
        public string Text { get; set; } = string.Empty;
<<<<<<< HEAD
        public string QuestionType { get; set; } = string.Empty; 
=======
        public string QuestionType { get; set; } = string.Empty; // MCQ, True/False, etc.
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
    }
}