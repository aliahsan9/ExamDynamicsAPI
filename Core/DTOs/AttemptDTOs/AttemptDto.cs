namespace ExamDynamicsAPI.Core.DTOs.AttemptDTOs
{
    public class AttemptDto
    {
        public int AttemptId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public DateTime AttemptDate { get; set; }
        public double Score { get; set; }
    }
}