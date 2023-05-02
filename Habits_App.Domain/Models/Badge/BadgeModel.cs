using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Models.Badge
{
    public class BadgeModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
