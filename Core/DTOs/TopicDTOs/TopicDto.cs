using ExamDynamicsAPI.Core.DTOs.SubjectDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.DTOs.TopicDTOs
{
    public class TopicDto
{
    public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    public int SubjectId { get; set; }
    public SubjectDto? Subject { get; set; }
}
}