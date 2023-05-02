using Habits_App.Domain.Models.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Services
{
    public interface IBadgeService
    {
        Task<List<BadgeModel>> GetAll();

        Task Create(BadgeCreationModel badge);
    }
}
