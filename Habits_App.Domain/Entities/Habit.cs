using Habits_App.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Entities
{
    public class Habit : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public virtual ICollection<UserProfileHabit>? UserProfileHabits { get; set; }

        public virtual ICollection<UserProfile>? UserProfiles { get; set; }

        public virtual ICollection<Badge>? Badges { get; set; }
    }
}
