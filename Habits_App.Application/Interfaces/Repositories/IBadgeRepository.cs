using Habits_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habits_App.Application.Interfaces.Repositories
{
    public interface IBadgeRepository
    {
        Task<List<Badge>> GetAll();

        Task Create(Badge badge);
    }
}
