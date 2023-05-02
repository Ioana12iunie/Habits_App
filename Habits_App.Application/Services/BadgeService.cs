using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Entities;
using Habits_App.Domain.Models;
using Habits_App.Domain.Models.Badge;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IHabitRepository _habitRepository;
        private readonly ILogger<BadgeService> _logger;

        public BadgeService(IBadgeRepository badgeRepository, ILogger<BadgeService> logger, IHabitRepository habitRepository)
        {
            _badgeRepository = badgeRepository;
            _habitRepository = habitRepository;
            _logger = logger;
        }

        public async Task<List<BadgeModel>> GetAll()
        {
            var badgeDb = await _badgeRepository.GetAll();
            var list = new List<BadgeModel>();

            foreach (var badge in badgeDb)
            {
                var badgeModel = new BadgeModel
                {
                    Name = badge.Name,
                    Score = badge.Score
                };
                list.Add(badgeModel);
            }
            return list;
        }

        public async Task Create(BadgeCreationModel badge)
        {
            var habit = await _habitRepository.GetById(badge.HabitId);

            if (habit == null)
            {
                _logger.LogError($"OPS! A habit with id = {badge.HabitId} does not exist in the database");
                throw new KeyNotFoundException($"Habit with id = {badge.HabitId} does not exist");
            }

            var newBadge = new Badge
            {
                Id = new Guid(),
                Name = badge.Name,
                Score = badge.Score,
                HabitId = badge.HabitId,
                Habit = habit
            };

            await _badgeRepository.Create(newBadge);
        }

    }
}
