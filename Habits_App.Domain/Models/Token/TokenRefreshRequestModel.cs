using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Domain.Models
{
    public class TokenRefreshRequestModel
    {
        public string ExpiredToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
