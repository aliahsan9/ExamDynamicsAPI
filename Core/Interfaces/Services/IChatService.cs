
using ExamDynamicsAPI.Core.DTOs.ChatDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IChatService
    {
        Task<ChatResponseDto> GetAnswerAsync(ChatRequestDto request);
    }
}
