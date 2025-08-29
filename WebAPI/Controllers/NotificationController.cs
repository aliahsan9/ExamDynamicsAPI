using ExamDynamicsAPI.Core.DTOs.NotificationDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [AllowAnonymous]
        // GET: api/Notification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationReadDto>>> GetAll()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }
       [AllowAnonymous]
        // GET: api/Notification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationReadDto>> GetById(int id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }
       [AllowAnonymous]
        // GET: api/Notification/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<NotificationReadDto>>> GetByUserId(int userId)
        {
            var notifications = await _notificationService.GetByUserIdAsync(userId);
            return Ok(notifications);
        }
        [AllowAnonymous]
        // GET: api/Notification/user/{userId}/unread
        [HttpGet("user/{userId}/unread")]
        public async Task<ActionResult<IEnumerable<NotificationReadDto>>> GetUnreadByUserId(int userId)
        {
            var notifications = await _notificationService.GetUnreadByUserIdAsync(userId);
            return Ok(notifications);
        }

        // POST: api/Notification
        [HttpPost]
        public async Task<ActionResult<NotificationReadDto>> Create(NotificationCreateDto dto)
        {
            var createdNotification = await _notificationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdNotification.Id }, createdNotification);
        }

        // PUT: api/Notification/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<NotificationReadDto>> Update(int id, NotificationUpdateDto dto)
        {
            var updatedNotification = await _notificationService.UpdateAsync(id, dto);
            if (updatedNotification == null) return NotFound();
            return Ok(updatedNotification);
        }

        // DELETE: api/Notification/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _notificationService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
