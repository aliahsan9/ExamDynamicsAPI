namespace ExamDynamicsAPI.Core.DTOs.ResultDTOs
{
    public class ResultDto
    {
        public int ResultId { get; set; }
        public int AttemptId { get; set; }
        public double Score { get; set; }
        public string Grade { get; set; } = string.Empty;
    }
}