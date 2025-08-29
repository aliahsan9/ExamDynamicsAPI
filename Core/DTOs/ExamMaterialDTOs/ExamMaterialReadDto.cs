using System;

namespace ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs
{
    public class ExamMaterialReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ExamId { get; set; }
        public string? ExamTitle { get; set; }  // optional, mapped from Exam.Title
        public int? UserId { get; set; }
        public string? UserName { get; set; }   // optional, mapped from User.Name
    }
}
