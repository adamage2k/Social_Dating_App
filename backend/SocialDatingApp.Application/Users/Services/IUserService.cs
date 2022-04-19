using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
    }
}