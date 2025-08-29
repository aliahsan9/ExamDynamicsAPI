using System;

namespace ExamDynamicsAPI.Core.DTOs.ExamResultDTOs
{
    public class ExamResultDto
    {
        public int ResultId { get; set; }          // Primary Key
        public int UserId { get; set; }            // Reference to User
        public string UserName { get; set; } = string.Empty; // Optional: User full name
        public int ExamId { get; set; }            // Reference to Exam
        public string ExamTitle { get; set; } = string.Empty; // Optional: Exam title
        public double Score { get; set; }          // Score achieved
        public int TotalQuestions { get; set; }    // Total number of questions
        public int CorrectAnswers { get; set; }    // Number of correct answers
        public DateTime TakenAt { get; set; }      // Date and time exam was taken
    }
}
