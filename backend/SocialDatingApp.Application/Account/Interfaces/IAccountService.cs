using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Account.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<IdentityDTO> LoginAsync(LoginDTO loginDTO);
        Task<UserDTO> UpdateAsync(UserDTO loginDTO);
    }
}
