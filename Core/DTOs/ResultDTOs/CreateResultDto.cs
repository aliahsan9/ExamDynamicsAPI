namespace ExamDynamicsAPI.Core.DTOs.ResultDTOs
{
      public class CreateResultDto
    {
        public int AttemptId { get; set; }
        public double Score { get; set; }
        public string Grade { get; set; } = string.Empty;
    }

}