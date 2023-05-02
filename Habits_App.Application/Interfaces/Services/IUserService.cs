using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAll();

        Task<UserProfileModelBasicUser> ShowProfile(string username);


        Task<bool> DeleteUser(Guid id);

        Task<bool> UpdateById(Guid id, UserModel user);
    }
}
