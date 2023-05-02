using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Domain.Entities;
using Habits_App.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Repositories
{
    public class BadgeRepository : IBadgeRepository
    {
        private readonly AppDbContext _db;

        public BadgeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Badge>> GetAll()
        {
            return _db.Badges.ToList();
        }

        public async Task Create(Badge badge)
        {
            await _db.Badges.AddAsync(badge);
            await _db.SaveChangesAsync();
        }
    }
}
