using Habits_App.Domain.Entities;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Habits_App.Domain.Models.Badge;

namespace Habits_App.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserProfileService> _logger;

        public UserProfileService(IUserProfileRepository profileRepository, IUserRepository userRepository, ILogger<UserProfileService> logger)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _logger = logger;
        }

        public async Task CreateAdmin(UserProfileModel profile)
        {
            var newProfile = new UserProfile
            {
                Id = new Guid(),
                UserId = profile.UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Nickname = profile.Nickname,
                Birthday = profile.Birthday
            };

            await _profileRepository.Create(newProfile);
        }

        public async Task Create(UserProfileModelBasicUser profile)
        {
            var newProfile = new UserProfile
            {
                Id = new Guid(),
                UserId = _userRepository.GetIdByUsername(profile.UserName),
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Nickname = profile.Nickname,
                Birthday = profile.Birthday
            };

            await _profileRepository.Create(newProfile);
        }

        public async Task<List<UserProfileModel>> GetAll()
        {
            var profileDb = await _profileRepository.GetAll();
            var list = new List<UserProfileModel>();
            foreach (var profile in profileDb)
            {
                var profileModel = new UserProfileModel
                {
                    Id = profile.Id,
                    UserId = profile.UserId,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Nickname = profile.Nickname,
                    Birthday = profile.Birthday

                };
                list.Add(profileModel);
            }
            return list;
        }

        public async Task CreateRegister(RegisterBasicUserModel profile)
        {
            var newProfile = new UserProfile
            {
                Id = new Guid(),
                UserId = _userRepository.GetIdByUsername(profile.UserName),
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Nickname = profile.Nickname,
                Birthday = profile.Birthday
            };

            await _profileRepository.Create(newProfile);
        }

        public async Task<UserProfileModel> GetById(Guid id)
        {
            var profile = await _profileRepository.GetById(id);

            if (profile == null)
            {
                _logger.LogError($"OPS! An UserProfile with id = {id} does not exist in the database");
                throw new KeyNotFoundException($"UserProfile with id = {id} does not exist");
            }

            var rawProfile = new UserProfileModel
            {
                Id = profile.Id,
                UserId = profile.UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Nickname = profile.Nickname,
                Birthday = profile.Birthday
            };

            return rawProfile;
        }
        public async Task<UserProfileModel> GetByUserId(Guid id)
        {
            var profile = await _profileRepository.GetByUserId(id);

            if (profile == null)
            {
                _logger.LogError($"OPS! An UserProfile with id = {id} does not exist in the database");
                throw new KeyNotFoundException($"UserProfile with id = {id} does not exist");
            }

            var rawProfile = new UserProfileModel
            {
                Id = profile.Id,
                UserId = profile.UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Nickname = profile.Nickname,
                Birthday = profile.Birthday
            };

            return rawProfile;
        }

        public async Task<bool> DeleteUserProfile(Guid id)
        {
            var profileDb = await _profileRepository.GetById(id);

            if (profileDb != null)
            {
                await _profileRepository.DeleteUserProfile(profileDb);
                return true;
            }

            _logger.LogError($"OPS! An UserProfile with id = {id} does not exist in the database");
            throw new KeyNotFoundException($"UserProfile with id = {id} does not exist");
        }

        public async Task<bool> DeleteUserProfileByUserId(Guid id)
        {
            var profileDb = await _profileRepository.GetByUserId(id);
            if (profileDb != null)
            {
                await _profileRepository.DeleteUserProfile(profileDb);
                return true;
            }

            _logger.LogError($"OPS! An UserProfile with UserId = {id} does not exist in the database");
            throw new KeyNotFoundException($"UserProfile with UserId = {id} does not exist");
        }

    }
}
