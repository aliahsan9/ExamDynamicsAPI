namespace ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs
{
    public class UpdateStudyMaterialDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int TopicId { get; set; }
    }
}
