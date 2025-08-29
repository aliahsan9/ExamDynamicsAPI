namespace ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs
{
    public class UserExamProgressUpdateDto
    {
        public int CurrentQuestion { get; set; }
        public int Score { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
