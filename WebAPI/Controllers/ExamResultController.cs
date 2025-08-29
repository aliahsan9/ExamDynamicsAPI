using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamResultDTOs;
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
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        private readonly IMapper _mapper;

        public ExamResultController(IExamResultService examResultService, IMapper mapper)
        {
            _examResultService = examResultService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ExamResultDto>> Create([FromBody] ExamResultCreateDto dto)
        {
            var result = await _examResultService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.ResultId }, result);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamResultDto>> GetById(int id)
        {
            var result = await _examResultService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
      [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamResultDto>>> GetAll()
        {
            var results = await _examResultService.GetAllAsync();
            return Ok(results);
        }
       [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ExamResultDto>>> GetByUserId(int userId)
        {
            var results = await _examResultService.GetByUserIdAsync(userId);
            return Ok(results);
        }
       [Authorize]
        [HttpGet("exam/{examId}")]
        public async Task<ActionResult<IEnumerable<ExamResultDto>>> GetByExamId(int examId)
        {
            var results = await _examResultService.GetByExamIdAsync(examId);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExamResultUpdateDto dto)
        {
            var success = await _examResultService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _examResultService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
