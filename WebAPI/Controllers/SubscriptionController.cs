using ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs;
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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [AllowAnonymous]
        // ================= GET ALL =================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAll()
        {
            var subscriptions = await _subscriptionService.GetAllAsync();
            return Ok(subscriptions);
        }
         [AllowAnonymous]
        // ================= GET BY ID =================
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetById(int id)
        {
            var subscription = await _subscriptionService.GetByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> Create([FromBody] SubscriptionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subscription = await _subscriptionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = subscription.SubscriptionId }, subscription);
        }
        [Authorize]
        // ================= UPDATE =================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubscriptionUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _subscriptionService.UpdateAsync(id, dto);
            if (!success) return NotFound();

            return NoContent();
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _subscriptionService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }

        // ================= GET BY USER =================
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetByUserId(int userId)
        {
            var subscriptions = await _subscriptionService.GetByUserIdAsync(userId);
            return Ok(subscriptions);
        }
    }
}
