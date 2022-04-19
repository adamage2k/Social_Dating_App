using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Application.Users.Interfaces;
using SocialDatingApp.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var usersList = new List<UserDTO>();

            foreach (var user in users)
            {
                var userDTO = new UserDTO();
                userDTO.UserName = user.UserName;
                userDTO.FirstName = user.FirstName;
                userDTO.LastName = user.LastName;
                userDTO.Age = user.Age;
                userDTO.Email = user.Email;

                usersList.Add(userDTO);
            }

            return usersList;
        }
    }
}