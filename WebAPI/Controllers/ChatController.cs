using ExamDynamicsAPI.Core.DTOs.ChatDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskQuestion([FromBody] ChatRequestDto request)
        {
            var answer = await _chatService.GetAnswerAsync(request);
            return Ok(answer);
        }
    }
}
