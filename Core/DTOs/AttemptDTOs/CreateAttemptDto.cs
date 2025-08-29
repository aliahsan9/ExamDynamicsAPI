namespace ExamDynamicsAPI.Core.DTOs.AttemptDTOs
{
       public class CreateAttemptDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public double Score { get; set; }
    }
}