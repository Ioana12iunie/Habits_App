using Habits_App.Application.Interfaces.Services;
using Habits_App.Application.Services;
using Habits_App.Domain.Models.Badge;
using Habits_App.Habits_App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeService _badgeService;
        private readonly ILogger<BadgesController> _logger;
        public BadgesController(IBadgeService badgeService, ILogger<BadgesController> logger)
        {
            _badgeService = badgeService;
            _logger = logger;
        }

        [HttpGet("Get_All_Badges_BasicUser")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "BasicUser")]
        public async Task<List<BadgeModel>> GetBadges()
        {
            var badges = await _badgeService.GetAll();
            return badges;
        }


        [HttpPost("Create_Badge_Admin")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateHabit(BadgeCreationModel badge)
        {
            try
            {
                await _badgeService.Create(badge);

                return Ok(badge);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while creating Badge!");
                return BadRequest(e.Message);
            }
        }
    }
}
