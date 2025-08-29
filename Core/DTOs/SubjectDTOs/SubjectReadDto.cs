namespace ExamDynamicsAPI.Core.DTOs.SubjectDTOs
{
    public class SubjectReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ExamId { get; set; }
    }
}