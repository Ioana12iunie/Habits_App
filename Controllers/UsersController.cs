using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using Habits_App.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Habits_App.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Habits_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _profileService;
        private readonly ILogger<UserProfileController> _logger;

        public UsersController(IUserService userService, IUserProfileService profileService, ILogger<UserProfileController> logger)
        {
            _userService = userService;
            _profileService = profileService;
            _logger = logger;   
        }

        [HttpGet("Get_All_Users")]
        public async Task<List<UserModel>> GetAll()
        {
            var users = await _userService.GetAll();
            return users;
        }

        [HttpGet("Get_Profile_By_Username")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task<UserProfileModelBasicUser> GetProfile(string username)
        {
            var profile = await _userService.ShowProfile(username);
            return profile;
        }

        [HttpPut("Update_User_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task UpdateUser([FromRoute] Guid id, [FromBody] UserModel user)
        {
            user.Id = id;
            await _userService.UpdateById(id, user);
        }

        [HttpDelete("Delete_User_UserProfile_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task DeleteUserAndUserProfile(Guid id)
        {
            await _profileService.DeleteUserProfileByUserId(id);
            await _userService.DeleteUser(id);
        }
    }
}
