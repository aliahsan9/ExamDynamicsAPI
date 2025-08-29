using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class AiSessionService : IAiSessionService
    {
        private readonly IAiSessionRepository _sessionRepository;

        public AiSessionService(IAiSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<AiSession>> GetAllSessionsAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<AiSession?> GetSessionByIdAsync(int id)
        {
            return await _sessionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AiSession>> GetSessionsByUserIdAsync(int userId)
        {
            return await _sessionRepository.GetByUserIdAsync(userId);
        }

        public async Task AddSessionAsync(AiSession session)
        {
            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateSessionAsync(AiSession session)
        {
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeleteSessionAsync(int id)
        {
            await _sessionRepository.DeleteAsync(id);
        }
    }
}