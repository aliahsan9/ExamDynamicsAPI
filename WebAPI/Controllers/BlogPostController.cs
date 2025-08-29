using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.BlogPostDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetAll()
        {
            var posts = await _blogPostService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDto>> GetById(int id)
        {
            var post = await _blogPostService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpGet("published")]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetPublished()
        {
            var posts = await _blogPostService.GetPublishedPostsAsync();
            return Ok(posts);
        }

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetByAuthor(int authorId)
        {
            var posts = await _blogPostService.GetPostsByAuthorAsync(authorId);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPostDto>> Create([FromBody] CreateBlogPostDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // For now, authorId can be hardcoded or retrieved from context
            int authorId = 1; // TODO: replace with logged-in user id
            var created = await _blogPostService.CreateAsync(dto, authorId);
            return CreatedAtAction(nameof(GetById), new { id = created.BlogPostId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBlogPostDto dto)
        {
            var success = await _blogPostService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _blogPostService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
