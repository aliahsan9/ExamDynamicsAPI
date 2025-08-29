using ExamDynamicsAPI.Core.DTOs.MessageDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageReadDto>>> GetAll()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageReadDto>> GetById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<MessageReadDto>>> GetByUser(int userId)
        {
            var messages = await _messageService.GetMessagesByUserAsync(userId);
            return Ok(messages);
        }

        [HttpGet("user/{userId}/unread")]
        public async Task<ActionResult<IEnumerable<MessageReadDto>>> GetUnreadByUser(int userId)
        {
            var messages = await _messageService.GetUnreadMessagesByUserAsync(userId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<MessageReadDto>> Create([FromBody] MessageCreateDto dto)
        {
            var message = await _messageService.CreateMessageAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MessageUpdateDto dto)
        {
            var updated = await _messageService.UpdateMessageAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _messageService.DeleteMessageAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
