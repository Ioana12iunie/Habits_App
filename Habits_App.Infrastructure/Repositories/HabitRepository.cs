using Habits_App.Domain.Entities;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Domain.Models;
using Habits_App.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly AppDbContext _db;

        public HabitRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(Habit habit)
        {
            await _db.Habits.AddAsync(habit);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Habit>> GetAll()
        {
            return _db.Habits.ToList();
        }

        public async Task<List<Habit>> GetAllOrdered()
        {
            return _db.Habits.OrderBy(x => x.Category).ToList();
        }

        public async Task<Habit> GetById(Guid id)
        {
            var habit = _db.Habits.FirstOrDefault(h => h.Id == id);
            return habit;
        }

        public async Task<Habit> GetByName(string name)
        {
            var habit = _db.Habits.FirstOrDefault(h => h.Name == name);
            return habit;
        }

        public async Task<List<Habit>> GetAllByCategory(string category)
        {
            var habit = _db.Habits.Where(h => h.Category == category).ToList();
            return habit;
        }

        public async Task DeleteHabit(Habit habit)
        {
            _db.Habits.Remove(habit);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateById(Habit habit)
        {
            _db.Habits.Update(habit);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Badge>> GetAllBadgesForHabit(Guid Id)
        {
            return _db.Badges.Where(x => x.HabitId == Id).ToList();
        }
    }
}
