using Microsoft.EntityFrameworkCore;
using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Application.Users;
using SocialDatingApp.Core;
using SocialDatingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users =  await _context.Users.ToListAsync();

            var usersList = new List<UserDTO>();
            
            foreach(var user in users)
            {
                var userDTO = new UserDTO();
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