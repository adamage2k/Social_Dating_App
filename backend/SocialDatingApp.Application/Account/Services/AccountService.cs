using Microsoft.AspNetCore.Identity;
using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Application.Account.Interfaces;
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

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Age = user.Age;
            userDTO.Email = user.Email;
            return userDTO;
        }

        public async Task<IdentityDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new User();
            user.UserName = registerDTO.UserName;

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
                throw new ArgumentException();

            var userDTO = new IdentityDTO();
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Age = user.Age;
            userDTO.Email = user.Email;

            return userDTO;

        }
    }
}
