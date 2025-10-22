using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services;
using UserManagement.DataLayer.Interfaces;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserLoginRepository _userRepo;
        private readonly JwtTokenService _jwtService;

        public AuthController(IUserLoginRepository userRepo, JwtTokenService jwtService)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.DTOs.LoginRequestDto loginRequest)
        {
            var user = await _userRepo.GetUserByUsernameAsync(loginRequest.Username);
            if (user == null || user.Password != loginRequest.Password)
                return Unauthorized("Invalid username or password.");

            var token = _jwtService.GenerateToken(user.Id, user.Username);
            return Ok(new { Token = token });
        }
    }
}
