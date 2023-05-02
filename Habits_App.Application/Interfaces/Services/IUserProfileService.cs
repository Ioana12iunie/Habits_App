using Habits_App.Domain.Entities;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Services
{
    public interface IUserProfileService
    {
        Task CreateAdmin(UserProfileModel profile);

        Task Create(UserProfileModelBasicUser profile);

        Task<List<UserProfileModel>> GetAll();

        Task CreateRegister(RegisterBasicUserModel profile);

        Task<UserProfileModel> GetById(Guid id);

        Task<UserProfileModel> GetByUserId(Guid id);

        Task<bool> DeleteUserProfile(Guid id);

        Task<bool> DeleteUserProfileByUserId(Guid id);
    }
}
