using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habits_App.Domain.Entities.Auth;
using Habits_App.Domain.Entities;

namespace Habits_App.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.UserName)
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .IsRequired(false);

            builder.Property(x => x.DateModified)
                .IsRequired(false);


            builder.HasOne(x => x.UserProfile)
                .WithOne(u => u.User)
                .HasForeignKey<UserProfile>(x => x.UserId)
                .IsRequired(false);
        }
    }
}
