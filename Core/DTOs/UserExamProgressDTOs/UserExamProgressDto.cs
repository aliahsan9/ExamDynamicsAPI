using System;

namespace ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs
{
    public class UserExamProgressDto
    {
        public int Id { get; set; }               // Progress record ID
        public int UserId { get; set; }           // ID of the user
        public int TopicId { get; set; }          // ID of the topic
        public double ProgressPercentage { get; set; } // 0-100%
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
