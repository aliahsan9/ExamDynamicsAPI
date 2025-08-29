namespace ExamDynamicsAPI.Core.DTOs.TopicDTOs
{
    public class CreateTopicDto
    {
        public string Name { get; set; } = string.Empty;
        public int SubjectId { get; set; }
    }

}