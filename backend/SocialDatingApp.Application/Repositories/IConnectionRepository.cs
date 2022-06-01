using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Repositories
{
    public interface IConnectionRepository
    {
        Task AddMatchAsync(Connection connection);
        Task<IEnumerable<UserDTO>> GetAllMatchesAsync(string userId);
    }
}
