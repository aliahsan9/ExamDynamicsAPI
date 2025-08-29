using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamRegistrationDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ExamRegistrationController : ControllerBase
    {
        private readonly IExamRegistrationService _examRegistrationService;
        private readonly IMapper _mapper;

        public ExamRegistrationController(IExamRegistrationService examRegistrationService, IMapper mapper)
        {
            _examRegistrationService = examRegistrationService;
            _mapper = mapper;
        }
        [Authorize]
        // GET: api/ExamRegistration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamRegistrationDto>>> GetAll()
        {
            var registrations = await _examRegistrationService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExamRegistrationDto>>(registrations));
        }
        [Authorize]
        // GET: api/ExamRegistration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamRegistrationDto>> GetById(int id)
        {
            var registration = await _examRegistrationService.GetByIdAsync(id);
            if (registration == null)
                return NotFound();

            return Ok(_mapper.Map<ExamRegistrationDto>(registration));
        }
       [Authorize]
        // POST: api/ExamRegistration
        [HttpPost]
        public async Task<ActionResult<ExamRegistrationDto>> Create([FromBody] ExamRegistrationCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registration = await _examRegistrationService.RegisterAsync(createDto);
            var registrationDto = _mapper.Map<ExamRegistrationDto>(registration);

            return CreatedAtAction(nameof(GetById), new { id = registrationDto.RegistrationId }, registrationDto);
        }

        // PUT: api/ExamRegistration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExamRegistrationUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _examRegistrationService.UpdateAsync(id, updateDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/ExamRegistration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _examRegistrationService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // GET: api/ExamRegistration/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ExamRegistrationDto>>> GetByUserId(int userId)
        {
            var registrations = await _examRegistrationService.GetByUserIdAsync(userId);
            return Ok(_mapper.Map<IEnumerable<ExamRegistrationDto>>(registrations));
        }

        // GET: api/ExamRegistration/exam/5
        [HttpGet("exam/{examId}")]
        public async Task<ActionResult<IEnumerable<ExamRegistrationDto>>> GetByExamId(int examId)
        {
            var registrations = await _examRegistrationService.GetByExamIdAsync(examId);
            return Ok(_mapper.Map<IEnumerable<ExamRegistrationDto>>(registrations));
        }
    }
}
