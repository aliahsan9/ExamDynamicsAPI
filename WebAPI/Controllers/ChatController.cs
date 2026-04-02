using ExamDynamicsAPI.Applications.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly OpenAIService _chatService;

    public ChatController(OpenAIService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> Ask([FromBody] string question)
    {
        await _chatService.AskQuestion(question);
        return Ok();
    }
}
}