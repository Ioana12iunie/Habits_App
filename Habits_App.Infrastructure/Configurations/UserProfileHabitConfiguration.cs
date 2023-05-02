using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habits_App.Domain.Entities;

namespace Habits_App.Infrastructure.Configurations
{
    public class UserProfileHabitConfiguration : IEntityTypeConfiguration<UserProfileHabit>
    {
        public void Configure(EntityTypeBuilder<UserProfileHabit> builder)
        {
            builder.HasKey(x => new { x.UserProfileId, x.HabitId });

            builder.Property(x => x.Active)
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.HasOne(x => x.UserProfile)
                .WithMany(p => p.UserProfileHabits)
                .HasForeignKey(p => p.UserProfileId);

            builder.HasOne(x => x.Habit)
                .WithMany(p => p.UserProfileHabits)
                .HasForeignKey(p => p.HabitId);
        }
    }
}
