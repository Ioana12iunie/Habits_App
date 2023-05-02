using Habits_App.Domain.Entities;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Habits_App.Domain.Models.Badge;

namespace Habits_App.Application.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitRepository _habitRepository;
        private readonly ILogger<HabitService> _logger;

        public HabitService(IHabitRepository habitRepository, ILogger<HabitService> logger)
        {
            _habitRepository = habitRepository;
            _logger = logger;
        }
        public async Task Create(HabitModel habit)
        {
            var newHabit = new Habit
            {
                Id = new Guid(),
                Name = habit.Name,
                Category = habit.Category,
            };

            await _habitRepository.Create(newHabit);
        }

        public async Task<List<HabitModel>> GetAll()
        {
            var habitDb = await _habitRepository.GetAll();
            var list = new List<HabitModel>();

            foreach (var habit in habitDb)
            {
                var habitModel = new HabitModel
                {
                    Name = habit.Name,
                    Category = habit.Category,

                };
                list.Add(habitModel);
            }
            return list;
        }

        public async Task<List<HabitModel>> GetAllOrdered()
        {
            var habitDb = await _habitRepository.GetAllOrdered();
            var list = new List<HabitModel>();

            foreach (var habit in habitDb)
            {
                var habitModel = new HabitModel
                {
                    Name = habit.Name,
                    Category = habit.Category,

                };
                list.Add(habitModel);
            }
            return list;
        }


        public async Task<List<HabitAdminModel>> GetAllAdmin()
        {
            var habitDb = await _habitRepository.GetAll();
            var list = new List<HabitAdminModel>();

            foreach (var habit in habitDb)
            {
                var habitAdminModel = new HabitAdminModel
                {
                    Id = habit.Id,
                    Name = habit.Name,
                    Category = habit.Category,
                };
                list.Add(habitAdminModel);
            }
            return list;
        }

        public async Task<List<HabitModel>> GetAllByCategory(string category)
        {
            var habitDb = await _habitRepository.GetAllByCategory(category);
            var list = new List<HabitModel>();

            foreach (var habit in habitDb)
            {
                var habitModel = new HabitModel
                {
                    Name = habit.Name,
                    Category = habit.Category,
                };
                list.Add(habitModel);
            }
            return list;
        }

        public async Task<HabitAdminModel> GetById(Guid id)
        {
            var habit = await _habitRepository.GetById(id);

            if (habit == null)
            {
                _logger.LogError($"OPS! A habit with id = {id} does not exist in the database");
                throw new KeyNotFoundException($"Habit with id = {id} does not exist");
            }

            var habitAdminModel = new HabitAdminModel
            {
                Id = habit.Id,
                Name = habit.Name,
                Category = habit.Category,
            };

            return habitAdminModel;
        }

        public async Task<HabitModel> GetByName(string name)
        {
            var habit = await _habitRepository.GetByName(name);

            if (habit == null)
            {
                _logger.LogError($"OPS! A habit with name = {name} does not exist in the database");
                throw new KeyNotFoundException($"Habit with name = {name} does not exist");
            }

            var habitModel = new HabitModel
            {
                Name = habit.Name,
                Category = habit.Category
            };

            return habitModel;
        }

        public async Task<bool> DeleteHabit(Guid id)
        {
            var habitDb = await _habitRepository.GetById(id);

            if (habitDb != null)
            {
                await _habitRepository.DeleteHabit(habitDb);
                return true;
            }

            _logger.LogError($"OPS! A habit with id = {id} does not exist in the database");
            throw new KeyNotFoundException($"Habit with id = {id} does not exist");
        }

        public async Task<bool> UpdateById(Guid id, HabitAdminModel habit)
        {
            var habitDb = await _habitRepository.GetById(id);

            if (habitDb != null)
            {
                habitDb.Id = id;
                habitDb.Name = habit.Name;
                habitDb.Category = habit.Category;

                await _habitRepository.UpdateById(habitDb);
                return true;
            }

            _logger.LogError($"OPS! A habit with id = {id} does not exist in the database");
            throw new KeyNotFoundException($"Habit with id = {id} does not exist");
        }

        public async Task<List<BadgeModel>> GetAllBagesForHabitId(Guid Id)
        {
            var badgeDb = await _habitRepository.GetAllBadgesForHabit(Id);
            var list = new List<BadgeModel>();

            foreach (var badge in badgeDb)
            {
                var badgeModel = new BadgeModel
                {
                    Name = badge.Name,
                    Score = badge.Score,
                };
                list.Add(badgeModel);
            }

            return list;
        }
    }
}
