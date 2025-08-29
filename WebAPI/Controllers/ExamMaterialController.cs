using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ExamMaterialsController : ControllerBase
    {
        private readonly IExamMaterialService _service;

        public ExamMaterialsController(IExamMaterialService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamMaterialReadDto>>> GetAll()
        {
            var materials = await _service.GetAllAsync();
            return Ok(materials);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamMaterialReadDto>> GetById(int id)
        {
            var material = await _service.GetByIdAsync(id);
            if (material == null) return NotFound();
            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult<ExamMaterialReadDto>> Create(ExamMaterialCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExamMaterialUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
