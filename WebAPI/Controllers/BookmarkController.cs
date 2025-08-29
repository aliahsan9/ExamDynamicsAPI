using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.BookmarkDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _service;
        private readonly IMapper _mapper;

        public BookmarkController(IBookmarkService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookmarkDto>>> GetAll()
        {
            var bookmarks = await _service.GetAllAsync();
            return Ok(bookmarks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookmarkDto>> GetById(int id)
        {
            var bookmark = await _service.GetByIdAsync(id);
            if (bookmark == null) return NotFound();

            return Ok(bookmark);
        }

        [HttpPost]
        public async Task<ActionResult<BookmarkDto>> Create([FromBody] CreateBookmarkDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookmark = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = bookmark.BookmarkId }, bookmark);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookmarkDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BookmarkDto>>> GetByUserId(int userId)
        {
            var bookmarks = await _service.GetByUserIdAsync(userId);
            return Ok(bookmarks);
        }
    }
}
