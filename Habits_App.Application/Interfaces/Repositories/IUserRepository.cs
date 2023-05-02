using Habits_App.Domain.Entities;
using Habits_App.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task DeleteUser(User user);

        Guid GetIdByUsername(string username);

        Task<UserProfile> GetProfile(string username);

        Task<User> GetById(Guid id);

        Task UpdateById(User user);
    }
}
