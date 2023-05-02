using Habits_App.Domain.Models;
using Habits_App.Domain.Models.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Services
{
    public interface IHabitService
    {
        Task Create(HabitModel habit);
        Task<List<HabitModel>> GetAll();

        Task<List<HabitModel>> GetAllByCategory(string category);
        Task<List<HabitAdminModel>> GetAllAdmin();

        Task<HabitAdminModel> GetById(Guid id);

        Task<HabitModel> GetByName(string name);

        Task<bool> DeleteHabit(Guid id);

        Task<bool> UpdateById(Guid id, HabitAdminModel habit);

        Task<List<HabitModel>> GetAllOrdered();

        Task<List<BadgeModel>> GetAllBagesForHabitId(Guid Id);

    }
}
