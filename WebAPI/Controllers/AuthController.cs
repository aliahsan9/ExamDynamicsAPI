using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IActivityLogService _activityLog;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            IActivityLogService activityLog)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _activityLog = activityLog;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized("Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid email or password.");

            // Generate token
            var token = await _tokenService.GenerateJwtTokenAsync(user);

            // Get user roles
            var roles = await _userManager.GetRolesAsync(user);

            try
            {
                await _activityLog.LogAsync(user.Id, "Login", "Signed in successfully.");
            }
            catch
            {
                // Activity logging must not block authentication
            }

            return Ok(new
            {
                token,
                user = new
                {
                    id = user.Id,
                    username = user.UserName,
                    email = user.Email,
                    roles
                }
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            // Assign role
            await _userManager.AddToRoleAsync(user, model.Role);

            var created = await _userManager.FindByEmailAsync(model.Email);
            if (created == null)
                return BadRequest(new { message = "Registration failed after create." });

            var token = await _tokenService.GenerateJwtTokenAsync(created);
            var roles = await _userManager.GetRolesAsync(created);

            try
            {
                await _activityLog.LogAsync(created.Id, "AccountCreated", "Welcome to ExamDynamics — your account is ready.");
            }
            catch
            {
            }

            return Ok(new
            {
                message = "User registered successfully.",
                token,
                user = new
                {
                    id = created.Id,
                    username = created.UserName,
                    email = created.Email,
                    roles
                }
            });
        }
    }
 
    // DTOs
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Student"; // default role
    }
} 
