namespace ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs
{
    public class UserExamProgressReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int CurrentQuestion { get; set; }
        public int Score { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
