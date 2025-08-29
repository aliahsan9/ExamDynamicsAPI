using ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class StudyMaterialController : ControllerBase
    {
        private readonly IStudyMaterialService _studyMaterialService;

        public StudyMaterialController(IStudyMaterialService studyMaterialService)
        {
            _studyMaterialService = studyMaterialService;
        }
        [AllowAnonymous]
        // GET: api/studymaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyMaterialDto>>> GetAll()
        {
            var materials = await _studyMaterialService.GetAllAsync(); // ✅ fixed
            return Ok(materials);
        }
        [AllowAnonymous]
        // GET: api/studymaterial/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyMaterialDto>> GetById(int id)
        {
            var material = await _studyMaterialService.GetByIdAsync(id); // ✅ fixed
            if (material == null) return NotFound();
            return Ok(material);
        }

        // POST: api/studymaterial
        [HttpPost]
        public async Task<ActionResult<StudyMaterialDto>> Create([FromBody] CreateStudyMaterialDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var material = await _studyMaterialService.CreateAsync(createDto); // ✅ fixed
            return CreatedAtAction(nameof(GetById), new { id = material.Id }, material);
        }

        // PUT: api/studymaterial/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudyMaterialDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _studyMaterialService.UpdateAsync(id, updateDto); // ✅ fixed
            if (updated == null) return NotFound();

            return Ok(updated); // return updated material instead of NoContent
        }

        // DELETE: api/studymaterial/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _studyMaterialService.DeleteAsync(id); // ✅ fixed
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
