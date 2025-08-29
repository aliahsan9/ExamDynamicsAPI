using ExamDynamicsAPI.Core.DTOs.UserDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamicsAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync(); // ✅ FIX
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) // changed Guid → int ✅ FIX
        {
            var user = await _userService.GetUserByIdAsync(id); // ✅ FIX
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto) // ✅ FIX type
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(userDto); // ✅ FIX
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto userDto) // ✅ FIX type
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedUser = await _userService.UpdateUserAsync(id, userDto); // ✅ FIX
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) // Guid → int ✅ FIX
        {
            var result = await _userService.DeleteUserAsync(id); // ✅ FIX
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
