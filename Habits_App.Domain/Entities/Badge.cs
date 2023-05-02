using Habits_App.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Entities
{
    public class Badge : BaseEntity
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Guid HabitId;
        public virtual Habit Habit { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
