using Habits_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Habits_App.Application.Interfaces.Services
{
    public interface IAuthService
    {

        Task<LoginResult> Login(LoginModel loginModel);

        Task<LoginResult> Refresh(string refreshToken);

        Task Register(RegisterBasicUserModel registerModel); //RegisterBasicUserModel

        Task RegisterAdmin(RegisterAdminModel registerModel); //UserProfileModelBasicUser  RegisterAdminModel 
    }
}
