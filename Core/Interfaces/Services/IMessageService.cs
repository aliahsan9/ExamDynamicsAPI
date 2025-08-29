using ExamDynamicsAPI.Core.DTOs.MessageDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageReadDto>> GetAllMessagesAsync();
        Task<MessageReadDto?> GetMessageByIdAsync(int id);
        Task<IEnumerable<MessageReadDto>> GetMessagesByUserAsync(int userId);
        Task<IEnumerable<MessageReadDto>> GetUnreadMessagesByUserAsync(int userId);
        Task<MessageReadDto> CreateMessageAsync(MessageCreateDto dto);
        Task<bool> UpdateMessageAsync(int id, MessageUpdateDto dto);
        Task<bool> DeleteMessageAsync(int id);
    }
}
