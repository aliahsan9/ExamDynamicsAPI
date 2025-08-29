namespace ExamDynamicsAPI.Core.DTOs.SubjectDTOs
{
    public class CreateSubjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ExamId { get; set; }
    }
}