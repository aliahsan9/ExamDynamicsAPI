namespace ExamDynamicsAPI.Core.DTOs.ProgressDTOs
{
    public class ProgressDto
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int Percentage { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
