using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.FeedbackDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackReadDto>> GetAllAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackReadDto>>(feedbacks);
        }

        public async Task<FeedbackReadDto?> GetByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackWithUserAsync(id);
            return _mapper.Map<FeedbackReadDto?>(feedback);
        }

        public async Task<IEnumerable<FeedbackReadDto>> GetByUserIdAsync(int userId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<FeedbackReadDto>>(feedbacks);
        }

        public async Task<FeedbackReadDto> AddAsync(FeedbackCreateDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            await _feedbackRepository.AddAsync(feedback);
            return _mapper.Map<FeedbackReadDto>(feedback);
        }

        public async Task<FeedbackReadDto?> UpdateAsync(int id, FeedbackUpdateDto feedbackDto)
        {
            var existing = await _feedbackRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(feedbackDto, existing);
            await _feedbackRepository.UpdateAsync(existing);

            return _mapper.Map<FeedbackReadDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _feedbackRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _feedbackRepository.DeleteAsync(id);
            return true;
        }
    }
}
