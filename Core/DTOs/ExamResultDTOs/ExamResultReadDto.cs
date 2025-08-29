using System;

namespace ExamDynamicsAPI.Core.DTOs.ExamResultDTOs
{
    public class ExamResultReadDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string? UserName { get; set; }

        public int ExamId { get; set; }
        public string? ExamTitle { get; set; }

        public int Score { get; set; }
        public int TotalMarks { get; set; }
        public string? Grade { get; set; }
        public DateTime TakenAt { get; set; }
    }
}
