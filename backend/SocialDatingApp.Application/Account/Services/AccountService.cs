using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Application.Account.Interfaces;
using SocialDatingApp.Application.Helpers;
using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtService;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenService jwtService, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _httpContext = httpContext;
        }

        public async Task<IdentityDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);

            if (user is null)
                throw new ArgumentException();

            var result = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);

            if (!result.Succeeded)
                throw new ArgumentException();

            var userDTO = new IdentityDTO();
            userDTO.Id = user.Id;
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Age = user.Age;
            userDTO.Email = user.Email;
            userDTO.Token = _jwtService.CreateToken(user);
            return userDTO;
        }

        public async Task<IdentityDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new User();
            user.UserName = registerDTO.UserName;
            user.FirstName = registerDTO.FirstName;
            user.LastName = registerDTO.LastName;
            user.Age = registerDTO.Age;

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
                throw new ArgumentException();

            var userDTO = new IdentityDTO();
            userDTO.Id = user.Id;
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Age = user.Age;
            userDTO.Email = user.Email;
            userDTO.Token = _jwtService.CreateToken(user);

            return userDTO;

        }

        public async Task<UserDTO> UpdateAsync(UserDTO userDTO)
        {
            var user = await _userManager.GetUserAsync(_httpContext.HttpContext.User);

            user.UserName = userDTO.UserName;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Age = userDTO.Age;
            user.Email = userDTO.Email;
            user.Description = userDTO.Description;
            user.LookingFor = userDTO.LookingFor;
            user.Interests = userDTO.Interests;
            user.Localization = userDTO.Localization;

            await _userManager.UpdateAsync(user);

            return userDTO;
        }
    }
}
