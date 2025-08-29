using System;
using static ExamDynamicsAPI.Core.Models.Answer;
using static ExamDynamicsAPI.Core.Models.BlogPost;

namespace ExamDynamicsAPI.Core.Models
{
    public class UserQuiz
    {
        public int Id { get; set; }

        // Foreign Key for User
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // Foreign Key for Quiz
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }

        // Extra fields (optional)
        public DateTime AttemptDate { get; set; }
        public int Score { get; set; }
        public bool IsPassed { get; set; }
    }
}
