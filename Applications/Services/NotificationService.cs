using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.NotificationDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationReadDto>> GetAllAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificationReadDto>>(notifications);
        }

        public async Task<NotificationReadDto?> GetByIdAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            return _mapper.Map<NotificationReadDto?>(notification);
        }

        public async Task<IEnumerable<NotificationReadDto>> GetByUserIdAsync(int userId)
        {
            var notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<NotificationReadDto>>(notifications);
        }

        public async Task<IEnumerable<NotificationReadDto>> GetUnreadByUserIdAsync(int userId)
        {
            var notifications = await _notificationRepository.GetUnreadNotificationsAsync(userId);
            return _mapper.Map<IEnumerable<NotificationReadDto>>(notifications);
        }

        public async Task<NotificationReadDto> AddAsync(NotificationCreateDto notificationDto)
        {
            var notification = _mapper.Map<Notification>(notificationDto);
            await _notificationRepository.AddAsync(notification);
            return _mapper.Map<NotificationReadDto>(notification);
        }

        public async Task<NotificationReadDto?> UpdateAsync(int id, NotificationUpdateDto notificationDto)
        {
            var existing = await _notificationRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(notificationDto, existing);
            await _notificationRepository.UpdateAsync(existing);

            return _mapper.Map<NotificationReadDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _notificationRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _notificationRepository.DeleteAsync(id);
            return true;
        }
    }
}
