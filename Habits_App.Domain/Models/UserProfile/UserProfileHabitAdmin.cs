using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Models.UserProfile
{
    public class UserProfileHabitAdmin
    {
        [Required(ErrorMessage = "UserProfileId is required")]
        public Guid UserProfileId;

        [Required(ErrorMessage = "HabitId is required")]
        public Guid HabitId;
    }
}
