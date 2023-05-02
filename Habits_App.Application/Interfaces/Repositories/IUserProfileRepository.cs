using Habits_App.Domain.Entities;
using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task Create(UserProfile profile);
        Task<List<UserProfile>> GetAll();
        Task<UserProfile> GetById(Guid id);
        Task<UserProfile> GetByUserId(Guid id);
        Task DeleteUserProfile(UserProfile profile);
        Task DeleteUserProfileByUserId(Guid id);
    }
}
