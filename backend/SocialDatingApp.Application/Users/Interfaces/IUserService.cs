using SocialDatingApp.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetSelfAsync();
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<IEnumerable<UserDTO>> GetAllMatchesAsync();
    }
}
