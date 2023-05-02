using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habits_App.Domain.Entities.Auth;
using Habits_App.Domain.Entities;
using Habits_App.Infrastructure.Configurations;

namespace Habits_App.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<
            User,
            Role,
            Guid,
            IdentityUserClaim<Guid>,
            UserRole,
            IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>
          >
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public override DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileHabit> UserProfileHabits { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileHabitConfiguration());
            modelBuilder.ApplyConfiguration(new HabitConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());

            modelBuilder.Entity<User>(b =>
            {
                b.HasMany(u => u.UserRoles)
                 .WithOne(ur => ur.User)
                 .HasForeignKey(ur => ur.UserId)
                 .IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.HasMany(u => u.UserRoles)
                 .WithOne(ur => ur.Role)
                 .HasForeignKey(ur => ur.RoleId)
                 .IsRequired();
            });
        }
    }
}
