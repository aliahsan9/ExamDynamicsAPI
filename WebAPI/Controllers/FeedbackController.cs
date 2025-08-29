using ExamDynamicsAPI.Core.DTOs.FeedbackDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: api/Feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackReadDto>>> GetAll()
        {
            var feedbacks = await _feedbackService.GetAllAsync();
            return Ok(feedbacks);
        }

        // GET: api/Feedback/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackReadDto>> GetById(int id)
        {
            var feedback = await _feedbackService.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        // GET: api/Feedback/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<FeedbackReadDto>>> GetByUserId(int userId)
        {
            var feedbacks = await _feedbackService.GetByUserIdAsync(userId);
            return Ok(feedbacks);
        }

        // POST: api/Feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackReadDto>> Create(FeedbackCreateDto dto)
        {
            var createdFeedback = await _feedbackService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdFeedback.Id }, createdFeedback);
        }

        // PUT: api/Feedback/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<FeedbackReadDto>> Update(int id, FeedbackUpdateDto dto)
        {
            var updatedFeedback = await _feedbackService.UpdateAsync(id, dto);
            if (updatedFeedback == null) return NotFound();
            return Ok(updatedFeedback);
        }

        // DELETE: api/Feedback/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _feedbackService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
