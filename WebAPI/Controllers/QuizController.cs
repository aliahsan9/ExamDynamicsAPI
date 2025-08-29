using System.Collections.Generic;
using System.Threading.Tasks;
using ExamDynamicsAPI.Core.DTOs.QuizDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(Roles = "Admin")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        // [AllowAnonymous]
        // GET: api/quiz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetAll()
        {
            var quizzes = await _quizService.GetAllQuizzesAsync();
            return Ok(quizzes);
        }
        //  [AllowAnonymous]
        // GET: api/quiz/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDto>> GetById(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }

        // POST: api/quiz
        [HttpPost]
        public async Task<ActionResult<QuizDto>> Create([FromBody] QuizCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var quiz = await _quizService.CreateQuizAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = quiz.Id }, quiz);
        }

        // PUT: api/quiz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuizUpdateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedQuiz = await _quizService.UpdateQuizAsync(id, updateDto);
            if (updatedQuiz == null) return NotFound();

            return NoContent();
        }

        // DELETE: api/quiz/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _quizService.DeleteQuizAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
