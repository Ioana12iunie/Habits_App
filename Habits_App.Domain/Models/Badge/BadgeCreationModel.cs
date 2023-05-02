using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Models.Badge
{
    public class BadgeCreationModel
    {
        [Required(ErrorMessage = "HabitId is required")]
        public Guid HabitId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public int Score { get; set; }
    }
}
