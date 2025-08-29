using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // POST: api/Email/Send
        [HttpPost("Send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _emailService.SendEmailAsync(request.To, request.Subject, request.Body);
                return Ok(new { Message = "Email sent successfully." });
            }
            catch (Exception ex)
            {
                // log exception if needed
                return StatusCode(500, new { Message = "Failed to send email.", Details = ex.Message });
            }
        }
    }

    // DTO for email request
    public class EmailRequest
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
