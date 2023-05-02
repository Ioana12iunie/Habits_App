using Habits_App.Domain.Entities.Auth;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Infrastructure.Context;
using Habits_App.Infrastructure.Repositories;
using Habits_App.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Habits_App.Infrastructure
{
    public static class ConfigureInfrastructure
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HabitsDb");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
           services.AddTransient<IHabitRepository, HabitRepository>();
           services.AddTransient<IUserProfileRepository, UserProfileRepository>();
           services.AddTransient<IUserRepository, UserRepository>();
           services.AddTransient<IBadgeRepository, BadgeRepository>();
           services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static async Task RunMigrationsAndSeedersAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();

            var seeder = serviceProvider.GetRequiredService<InitSeeder>();
            await seeder.SeedRoles();
            await seeder.SeedAdmins();

            var habitsSeeder = serviceProvider.GetRequiredService<HabitsSeeder>();
            await habitsSeeder.SeedHabits();

            var badgesSeeder = serviceProvider.GetRequiredService<BadgesSeeder>();
            await badgesSeeder.SeedBadges();
        }
    }
}