using Habits_App.Domain.Entities.Auth;
using Habits_App.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Seeders
{
    public class InitSeeder
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public InitSeeder(RoleManager<Role> roleManager, UserManager<User> userManager, AppDbContext projectContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = projectContext;
        }


        public async Task SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            string[] roleNames = {
                "Admin",
                "BasicUser",
                "PremiumUser"
            };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    continue;
                }

                await _roleManager.CreateAsync(new Role { Name = roleName });
                await _context.SaveChangesAsync();
            }
        }

        public async Task SeedAdmins()
        {

            var usersExist = this._context.Users.Any();
            if (usersExist)
            {
                return;
            }

            User[] rawAdmins = new User[] {
               new User { UserName = "admin_habits_1", Email = "admin_habits_1@gmail.com", DateCreated = DateTime.Now, DateModified = DateTime.Now},
               new User { UserName = "admin_habits_2", Email = "admin_habits_2@gmail.com", DateCreated = DateTime.Now, DateModified = DateTime.Now}
            };

            foreach (var rawU in rawAdmins)
            {
                await this._userManager.CreateAsync(rawU, "Pa$$w0rd1");
                await this._userManager.AddToRoleAsync(rawU, "Admin");
            }
        }
    }
}
