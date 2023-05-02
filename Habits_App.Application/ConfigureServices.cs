using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Application.Services;
using Habits_App.Habits_App.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Habits_App.Application
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IHabitService, HabitService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBadgeService, BadgeService>();
        }
    }
}