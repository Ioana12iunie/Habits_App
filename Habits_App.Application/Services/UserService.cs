using Habits_App.Domain.Entities;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Habits_App.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var userDb = await _userRepository.GetAll();
            var list = new List<UserModel>();
            foreach (var user in userDb)
            {
                var userModel = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.UserName,
                    DateModified= user.DateModified,
                    DateCreated = user.DateCreated,
                };
                list.Add(userModel);
            }
            return list;
        }

        public async Task<UserProfileModelBasicUser> ShowProfile(string username)
        {
            var profileDb = await _userRepository.GetProfile(username);
            var profile = new UserProfileModelBasicUser
            {
                UserName = username,
                FirstName = profileDb.FirstName,
                LastName = profileDb.LastName,
                Nickname = profileDb.Nickname,
                Birthday = profileDb.Birthday
            };

            return profile;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var userDb = await _userRepository.GetById(id);
            if (userDb != null)
            {
                await _userRepository.DeleteUser(userDb);
                return true;
            }

            _logger.LogError($"OPS! An user with id = {id} does not exist in the database");
            throw new KeyNotFoundException($"User with id = {id} does not exist");
        }

        public async Task<bool> UpdateById(Guid id, UserModel user)
        {
            var userDb = await _userRepository.GetById(id);
            if (userDb != null)
            {
                userDb.Id = id;
                userDb.UserName = user.Username;
                userDb.Email = user.Email;
                userDb.DateModified = DateTime.Now;

                await _userRepository.UpdateById(userDb);
                return true;
            }

            _logger.LogError($"OPS! An user with id = {id} does not exist in the database");
            throw new KeyNotFoundException($"User with id = {id} does not exist");
        }

    }
}
