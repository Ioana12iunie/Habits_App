using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using Habits_App.Domain.Models.Badge;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Habits_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;
        private readonly ILogger<HabitsController> _logger;

        public HabitsController(IHabitService habitService, ILogger<HabitsController> logger)
        {
            _habitService = habitService;
            _logger = logger;
        }

        [HttpPost("Create_Habit_Admin")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateHabit(HabitModel habit)
        {
            await _habitService.Create(habit);
            return Ok(habit);
        }

        [HttpGet("Get_All_Habits_Admin")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<List<HabitAdminModel>> GetHabitsAdmin()
        {
            var habits = await _habitService.GetAllAdmin();
            return habits;
        }

        [HttpGet("Get_All_Habits_BasicUser")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task<List<HabitModel>> GetHabits()
        {
            var habits = await _habitService.GetAll();
            return habits;
        }

        [HttpGet("Get_All_Habits_Ordered_By_Category_BasicUser")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task<List<HabitModel>> GetHabitsOrdered()
        {
            var habits = await _habitService.GetAllOrdered();
            return habits;
        }


        [HttpGet("Get_All_By_Category_{category}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task<List<HabitModel>> GetAllByCategory(string category)
        {
            var habits = await _habitService.GetAllByCategory(category);
            return habits;
        }


        [HttpGet("Get_Habit_By_Id_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<HabitAdminModel> GetHabitById(Guid id)
        {
            var habit = await _habitService.GetById(id);
            return habit;
        }

        [HttpGet("Get_Habit_By_Name_{name}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, BasicUser")]
        public async Task<HabitModel> GetHabitByName(string name)
        {
            var habit = await _habitService.GetByName(name);
            return habit;
        }


        [HttpGet("Get_All_Badges_For_HabitId")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<List<BadgeModel>> GetBadgesForHabitIt(Guid Id)
        {
            var habits = await _habitService.GetAllBagesForHabitId(Id);
            return habits;
        }


        [HttpPut("Update_Habit_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateHabit([FromRoute] Guid id, [FromBody] HabitAdminModel habit)
        {
            habit.Id = id;
            await _habitService.UpdateById(id, habit);

            return Ok("Updated succesfully");
        }

        [HttpDelete("Delete_Habit_{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteHabit(Guid id)
        {
            await _habitService.DeleteHabit(id);

            return Ok("Deleted succesfully");
        }

    }
}
