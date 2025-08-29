using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class UserExamProgress
    {
        [Key] 
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ExamId { get; set; }

        public int CurrentQuestion { get; set; } = 0;
        public int Score { get; set; } = 0;

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}
