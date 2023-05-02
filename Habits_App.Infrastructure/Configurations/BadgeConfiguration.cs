using Habits_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Infrastructure.Configurations
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .HasColumnType("nvarchar(100)")
              .HasMaxLength(100);

            builder.Property(x => x.Score)
              .HasColumnType("int");

            builder
             .HasMany(p => p.UserProfiles)
             .WithMany(b => b.Badges);


            builder.HasOne(x => x.Habit)
                .WithMany(b => b.Badges)
                .HasForeignKey(b => b.HabitId)
                .IsRequired(false);
        }
    }
}

