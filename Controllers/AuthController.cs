using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using Habits_App.Habits_App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserProfileService _profileService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, IUserProfileService profileService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _profileService = profileService;
            _logger = logger; 
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authService.Login(loginModel);
            return result.Success ? Ok(result) : BadRequest("Failed to login");
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var result = await _authService.Refresh(refreshToken);
            return result.Success ? Ok(result) : BadRequest("Failed to refresh Token");
        }

        [HttpPost("Register_BasicUser")]
        public async Task<IActionResult> RegisterBasicUser([FromBody] RegisterBasicUserModel registerModel) //UserProfileModelBasicUser  RegisterBasicUserModel
        {
            try
            {
                await _authService.Register(registerModel);
                await _profileService.CreateRegister(registerModel);

                return Ok("Registered user succesfully");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while registering a BasicUser!");
                return BadRequest(e.Message);
            }

        }

        [HttpPost("Register_Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminModel registerModel)
        {
            try
            {
                await _authService.RegisterAdmin(registerModel);

                return Ok("Registered admin succesfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
