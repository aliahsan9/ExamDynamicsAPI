using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.MessageDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessageReadDto> CreateMessageAsync(MessageCreateDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            await _repository.AddAsync(message);
            return _mapper.Map<MessageReadDto>(message);
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MessageReadDto>> GetAllMessagesAsync()
        {
            var messages = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MessageReadDto>>(messages);
        }

        public async Task<MessageReadDto?> GetMessageByIdAsync(int id)
        {
            var message = await _repository.GetByIdAsync(id);
            return message == null ? null : _mapper.Map<MessageReadDto>(message);
        }

        public async Task<IEnumerable<MessageReadDto>> GetMessagesByUserAsync(int userId)
        {
            var messages = await _repository.GetMessagesByUserAsync(userId);
            return _mapper.Map<IEnumerable<MessageReadDto>>(messages);
        }

        public async Task<IEnumerable<MessageReadDto>> GetUnreadMessagesByUserAsync(int userId)
        {
            var messages = await _repository.GetUnreadMessagesByUserAsync(userId);
            return _mapper.Map<IEnumerable<MessageReadDto>>(messages);
        }

        public async Task<bool> UpdateMessageAsync(int id, MessageUpdateDto dto)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
                return false;

            _mapper.Map(dto, message);
            await _repository.UpdateAsync(message);
            return true;
        }
    }
}
