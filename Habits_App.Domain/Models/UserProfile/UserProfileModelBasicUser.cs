using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Models
{
    public class UserProfileModelBasicUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string? Nickname { get; set; }
        public DateTime? Birthday { get; set; }
        public string UserName { get; set; }
    }
}
