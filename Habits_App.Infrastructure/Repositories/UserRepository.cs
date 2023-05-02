using Habits_App.Domain.Entities;
using Habits_App.Domain.Entities.Auth;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAll()
        {
            return _db.Users.ToList();
        }

        public async Task DeleteUser(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public Guid GetIdByUsername(string username)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);
            return user.Id;
        }

        public async Task<UserProfile> GetProfile(string username)
        {
            var profile = _db.UserProfiles.FirstOrDefault(p => p.UserId == GetIdByUsername(username));
            if (profile != null) return profile;
            return null;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public async Task UpdateById(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
