﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialDatingApp.Application.Account.DTOs;
using SocialDatingApp.Application.Services;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialDatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<User> Register(RegisterDTO registerDTO)
        {
            return await _accountService.RegisterAsync(registerDTO);
        }

        [HttpPost("Login")]
        public async Task<User> Login(LoginDTO loginDTO)
        {
            return await _accountService.LoginAsync(loginDTO);
        }

    }
}