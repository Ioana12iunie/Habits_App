using Habits_App.Domain.Entities;
using Habits_App.Domain.Entities.Auth;
using Habits_App.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Seeders
{
    public class HabitsSeeder
    {
        private readonly AppDbContext _context;

        public HabitsSeeder(AppDbContext projectContext)
        {
            _context = projectContext;
        }

        public async Task SeedHabits()
        {
            if (_context.Habits.Any())
            {
                return;
            }

            Habit[] rawHabits = new Habit[] {
               new Habit { Name = "Water Flowers", Category = "Environment"},
               new Habit { Name = "Recycle Plastic Bottles", Category = "Environment"},
               new Habit { Name = "Recycle Paper", Category = "Environment"},
               new Habit { Name = "Recycle Glass", Category = "Environment"},
               new Habit { Name = "Quit coffee", Category = "Health"},
               new Habit { Name = "Quit fast food", Category = "Health"},
               new Habit { Name = "Quit smoking", Category = "Health"},
               new Habit { Name = "Eat a fruit daily", Category = "Health"},
               new Habit { Name = "Exercise daily", Category = "Fitness"},
               new Habit { Name = "Run in the morning", Category = "Fitness"},
               new Habit { Name = "Meditate", Category = "Spiritual"},
               new Habit { Name = "Read", Category = "Spiritual"},
               new Habit { Name = "Spend time with friends", Category = "Social"},
               new Habit { Name = "Spend time with family", Category = "Social"},
               new Habit { Name = "Learn about Cloud Technology", Category = "Learning"},
               new Habit { Name = "Learn a new recipe", Category = "Learning"},
            };

            _context.Habits.AddRange(rawHabits);
            _context.SaveChanges();
        }
    }
}
