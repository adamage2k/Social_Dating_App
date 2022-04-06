using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Services
{
    public interface IAccountService
    {
        Task<UserDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<UserDTO> LoginAsync(LoginDTO loginDTO);
    }
}
