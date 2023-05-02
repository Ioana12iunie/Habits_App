using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using Habits_App.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Habits_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _profileService;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(IUserProfileService profileService, ILogger<UserProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpPost("Create_UserProfile")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateUserProfile(UserProfileModel profile)
        {
            await _profileService.CreateAdmin(profile);
            return Ok(profile);
        }

        [HttpPost("Create_UserProfile_BasicUser")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateUserProfile(UserProfileModelBasicUser profile)
        {
            await _profileService.Create(profile);
            return Ok(profile);
        }


        [HttpGet("Get_All_UserProfiles")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<List<UserProfileModel>> GetAll()
        {
            var profiles = await _profileService.GetAll();
            return profiles;
        }

        [HttpGet("Get_UserProfile_By_Id_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<UserProfileModel> GetProfileById(Guid id)
        {
            var profile = await _profileService.GetById(id);
            return profile;
        }

        [HttpGet("Get_UserProfile_By_UserId_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<UserProfileModel> GetProfileByUserId(Guid id)
        {
            var profile = await _profileService.GetByUserId(id);
            return profile;
        }

        [HttpPost("Create_UserProfile_Register")]
        public async Task<IActionResult> CreateUserProfile(RegisterBasicUserModel profile)
        {
            await _profileService.CreateRegister(profile);
            return Ok(profile);
        }

        [HttpDelete("Delete_UserProfile_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task DeleteUserProfile(Guid id)
        {
            await _profileService.DeleteUserProfile(id);
        }

        [HttpDelete("Delete_UserProfile_By_UserId_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task DeleteUserProfileByUserId(Guid id)
        {
            await _profileService.DeleteUserProfileByUserId(id);
        }

    }
}
