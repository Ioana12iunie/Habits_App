using Habits_App.Domain.Entities;
using Habits_App.Infrastructure.Context;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Seeders
{
    public class BadgesSeeder
    {
        private readonly AppDbContext _context;

        public BadgesSeeder(AppDbContext projectContext)
        {
            _context = projectContext;
        }

        public async Task SeedBadges()
        {
            if (_context.Badges.Any())
            {
                return;
            }

            if (_context.Habits.Any()) {
                Badge[] rawBadges = {};
                Array.Resize(ref rawBadges, rawBadges.Length + _context.Habits.Count());
                int i = 0;

                foreach (var habit in _context.Habits)
                {
                    Badge b = new Badge { Name = "Completed Habit Badge", Score = 100, HabitId = habit.Id};
                    rawBadges[i] = b;
                    i += 1;
                    
                }

                _context.Badges.AddRange(rawBadges);
                _context.SaveChanges();
            }
        }
    }
}
