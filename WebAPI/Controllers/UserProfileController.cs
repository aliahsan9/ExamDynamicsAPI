using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetAll()
        {
            var profiles = await _service.GetAllAsync();
            return Ok(profiles);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserProfileDto>> GetById(int userId)
        {
            var profile = await _service.GetByIdAsync(userId);
            if (profile is null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileDto>> Create([FromBody] UserProfileCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var profile = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { userId = profile.UserId }, profile);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(int userId, [FromBody] UserProfileUpdateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _service.UpdateAsync(userId, updateDto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var success = await _service.DeleteAsync(userId);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserProfileDto>> GetByEmail(string email)
        {
            var profile = await _service.GetByEmailAsync(email);
            if (profile is null) return NotFound();
            return Ok(profile);
        }
    }
}
