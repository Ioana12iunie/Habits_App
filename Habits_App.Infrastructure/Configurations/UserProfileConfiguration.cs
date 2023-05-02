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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.Nickname)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Birthday)
                .HasColumnType("datetime")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(p => p.UserId)
                .IsRequired(false);

            builder
                .HasMany(s => s.Habits)
                .WithMany(c => c.UserProfiles)
                .UsingEntity<UserProfileHabit>();
        }
    }
}
