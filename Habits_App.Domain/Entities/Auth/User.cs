using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual UserProfile? UserProfile { get; set; }
    }
}
