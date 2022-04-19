using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialDatingApp.Application.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;
        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork,IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<UserDTO>> GetAllMatchesAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContext.HttpContext.User);
            
            return await _unitOfWork.ConnectionRepository.GetAllMatchesAsync(user.Id);

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