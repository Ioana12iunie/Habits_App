using Habits_App.Domain.Entities.Auth;
using Habits_App.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Nickname { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? DateModified { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<UserProfileHabit>? UserProfileHabits { get; set; }

        public virtual ICollection<Habit>? Habits { get; set; }

        public ICollection<Badge>? Badges { get; set; }
    }
}
