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
    public class HabitConfiguration : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .HasColumnType("nvarchar(100)")
              .HasMaxLength(100);

            builder.Property(x => x.Category)
              .HasColumnType("nvarchar(50)")
              .HasMaxLength(50);

            builder
             .HasMany(s => s.UserProfiles)
             .WithMany(c => c.Habits)
             .UsingEntity<UserProfileHabit>();
        }
    }
}
