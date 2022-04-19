using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialDatingApp.Application.Users;
using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Application.Users.Interfaces;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialDatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("Get")]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("GetMatches")]
        public async Task<IEnumerable<UserDTO>> GetAllMatches()
        {
            return await _userService.GetAllMatchesAsync();
        }
    }
}
