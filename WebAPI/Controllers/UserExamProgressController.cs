using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserExamProgressController : ControllerBase
    {
        private readonly IUserExamProgressService _service;

        public UserExamProgressController(IUserExamProgressService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserExamProgressReadDto>>> GetAll()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }
       [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserExamProgressReadDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserExamProgressReadDto>>> GetByUserId(int userId)
        {
            var results = await _service.GetByUserIdAsync(userId);
            return Ok(results);
        }

        [HttpGet("exam/{examId}")]
        public async Task<ActionResult<IEnumerable<UserExamProgressReadDto>>> GetByExamId(int examId)
        {
            var results = await _service.GetByExamIdAsync(examId);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<UserExamProgressReadDto>> Create([FromBody] UserExamProgressCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserExamProgressUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
