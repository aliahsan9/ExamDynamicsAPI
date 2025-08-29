using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await _topicRepository.GetAllAsync();
        }

        public async Task<Topic?> GetTopicByIdAsync(int id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Topic>> GetTopicsBySubjectIdAsync(int subjectId)
        {
            return await _topicRepository.GetBySubjectIdAsync(subjectId);
        }

        public async Task AddTopicAsync(Topic topic)
        {
            await _topicRepository.AddAsync(topic);
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            await _topicRepository.UpdateAsync(topic);
        }

        public async Task DeleteTopicAsync(int id)
        {
            await _topicRepository.DeleteAsync(id);
        }
    }
}