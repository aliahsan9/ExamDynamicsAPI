namespace ExamDynamicsAPI.Core.DTOs.ProgressDTOs
{
    public class CreateProgressDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int Percentage { get; set; }
    }
}
