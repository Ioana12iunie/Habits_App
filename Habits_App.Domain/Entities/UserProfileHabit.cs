using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Entities
{
    public class UserProfileHabit
    {
        public Guid UserProfileId { get; set; }
        public Guid HabitId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Habit Habit { get; set; }

        public bool Active { get; set; }
    }
}
