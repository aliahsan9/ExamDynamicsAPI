using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamDynamicsAPI.Infrastructure.Data; // your DbContext
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs.TopicDTOs;
using ExamDynamicsAPI.Core.DTOs.SubjectDTOs;
using Microsoft.AspNetCore.Authorization;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TopicController : ControllerBase
    {
        private readonly ExamDynamicsDbContext _context;

        public TopicController(ExamDynamicsDbContext context)
        {
            _context = context;
        }
         [AllowAnonymous]
        // GET: api/Topic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics()
        {
            var topics = await _context.Topics
                .Include(t => t.Subject)
                .Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    SubjectId = t.Subject!.SubjectId,
                    Subject = new SubjectDto
                    {
                        Id = t.Subject.SubjectId,
                        Name = t.Subject.Name
                    }
                })
                .ToListAsync();

            return Ok(topics);
        }
        [AllowAnonymous]
        // GET: api/Topic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDto>> GetTopic(int id)
        {
            var topic = await _context.Topics
                .Include(t => t.Subject)
                .Where(t => t.Id == id)
                .Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    SubjectId = t.Subject!.SubjectId,
                    Subject = new SubjectDto
                    {
                        Id = t.Subject.SubjectId,
                        Name = t.Subject.Name
                    }
                })
                .FirstOrDefaultAsync();

            if (topic == null)
                return NotFound();

            return Ok(topic);
        }

        // POST: api/Topic
        [HttpPost]
        public async Task<ActionResult<TopicDto>> CreateTopic([FromBody] Topic topic)
        {
            if (topic == null)
                return BadRequest("Topic is null");

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            // Return the created topic
            var topicDto = new TopicDto
            {
                Id = topic.Id,
                Name = topic.Name,
                SubjectId = topic.SubjectId,
                Subject = new SubjectDto
                {
                    Id = topic.Subject!.SubjectId,
                    Name = topic.Subject.Name
                }
            };

            return CreatedAtAction(nameof(GetTopic), new { id = topic.Id }, topicDto);
        }

        // PUT: api/Topic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] Topic topic)
        {
            if (id != topic.Id)
                return BadRequest("Topic ID mismatch");

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return NotFound();

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(t => t.Id == id);
        }
    }
}
