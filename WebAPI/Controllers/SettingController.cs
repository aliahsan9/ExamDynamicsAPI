using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.settingDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }
         [Authorize]
        // GET: api/Settings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var settings = await _settingService.GetAllAsync();
            return Ok(settings);
        }
        [Authorize]
        // GET: api/Settings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var setting = await _settingService.GetByIdAsync(id);
            if (setting == null)
                return NotFound();

            return Ok(setting);
        }
        [Authorize]
        // POST: api/Settings
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSettingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _settingService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SettingId }, created);
        }

        // PUT: api/Settings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSettingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.SettingId)
                return BadRequest("ID mismatch");

            var updated = await _settingService.UpdateAsync(dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Settings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _settingService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
