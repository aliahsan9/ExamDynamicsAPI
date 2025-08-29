namespace ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs
{
    public class StudyMaterialDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public string TopicName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
