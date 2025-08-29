using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetAllTopicsAsync();
        Task<Topic?> GetTopicByIdAsync(int id);
        Task<IEnumerable<Topic>> GetTopicsBySubjectIdAsync(int subjectId);
        Task AddTopicAsync(Topic topic);
        Task UpdateTopicAsync(Topic topic);
        Task DeleteTopicAsync(int id);
    }
}