using Habits_App.Domain.Entities;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Repositories
{
    public interface IHabitRepository
    {
        Task Create(Habit habit);
        Task<List<Habit>> GetAll();
        Task<List<Habit>> GetAllByCategory(string category);
        Task<Habit> GetById(Guid id);
        Task<Habit> GetByName(string name);

        Task DeleteHabit(Habit habit);

        Task UpdateById(Habit habit);

        Task<List<Habit>> GetAllOrdered();

        Task<List<Badge>> GetAllBadgesForHabit(Guid Id);
    }
}
