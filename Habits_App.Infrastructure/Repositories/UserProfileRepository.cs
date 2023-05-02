using Habits_App.Domain.Entities;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Habits_App.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _db;

        public UserProfileRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(UserProfile profile)
        {
            await _db.UserProfiles.AddAsync(profile);
            await _db.SaveChangesAsync();
        }

        public async Task<List<UserProfile>> GetAll()
        {
            return _db.UserProfiles.ToList();
        }

        public async Task<UserProfile> GetById(Guid id)
        {
            var profile = _db.UserProfiles.FirstOrDefault(p => p.Id == id);
            return profile;
        }

        public async Task<UserProfile> GetByUserId(Guid id)
        {
            var profile = _db.UserProfiles.FirstOrDefault(p => p.UserId == id);
            return profile;
        }

        public async Task DeleteUserProfile(UserProfile profile)
        {
            _db.UserProfiles.Remove(profile);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserProfileByUserId(Guid id)
        {
            var profile = await GetByUserId(id);
            _db.UserProfiles.Remove(profile);
            await _db.SaveChangesAsync();
        }

        public async Task<List<UserProfileHabit>> GetUserProfileHabits()
        {
            var userProfileHabits = _db.UserProfileHabits.Include(x => x.UserProfile);
            return userProfileHabits.ToList();
        }
    }
}
