using ExamDynamicsAPI.Core.DTOs.FeedbackDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IFeedbackService
    {
        // Get all feedbacks
        Task<IEnumerable<FeedbackReadDto>> GetAllAsync();

        // Get feedback by ID
        Task<FeedbackReadDto?> GetByIdAsync(int id);

        // Get feedbacks by specific user
        Task<IEnumerable<FeedbackReadDto>> GetByUserIdAsync(int userId);

        // Add new feedback
        Task<FeedbackReadDto> AddAsync(FeedbackCreateDto feedbackDto);

        // Update feedback (admin response)
        Task<FeedbackReadDto?> UpdateAsync(int id, FeedbackUpdateDto feedbackDto);

        // Delete feedback
        Task<bool> DeleteAsync(int id);
    }
}
