using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IForgotPasswordService _service;
        private readonly IMapper _mapper;

        public ForgotPasswordController(IForgotPasswordService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // POST: api/ForgotPassword
        [HttpPost]
        public async Task<ActionResult<ForgotPasswordDto>> GenerateToken([FromBody] ForgotPasswordCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.GenerateTokenAsync(dto);
            return Ok(result);
        }

        // POST: api/ForgotPassword/reset
        [HttpPost("reset")]
        public async Task<ActionResult> ResetPassword([FromBody] ForgotPasswordResetDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _service.ResetPasswordAsync(dto);
            if (!success)
                return BadRequest("Invalid or expired token.");

            return Ok("Password reset successfully.");
        }
    }
}
