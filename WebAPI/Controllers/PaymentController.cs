using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.PaymentDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Create([FromBody] CreatePaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _paymentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.PaymentId }, result);
        }

        // ================= GET BY ID =================
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var result = await _paymentService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // ================= GET ALL =================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAll()
        {
            var results = await _paymentService.GetAllAsync();
            return Ok(results);
        }

        // ================= GET BY USER =================
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetByUserId(int userId)
        {
            var results = await _paymentService.GetByUserIdAsync(userId);
            return Ok(results);
        }

        // ================= GET SUCCESSFUL PAYMENTS =================
        [HttpGet("successful")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetSuccessfulPayments()
        {
            var results = await _paymentService.GetSuccessfulPaymentsAsync();
            return Ok(results);
        }

        // ================= UPDATE =================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _paymentService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _paymentService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
