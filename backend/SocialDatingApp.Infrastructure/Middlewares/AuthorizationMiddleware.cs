using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public readonly IConfiguration _config;

        public AuthorizationMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public Task InvokeAsync(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null)
            {
                string token = authHeader.Substring(7);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var jwtClaims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, jwtToken.Claims.First(x => x.Type == "sub").Value)
                });

                var claims = new ClaimsPrincipal(jwtClaims);

                context.User = claims;
            }

            return _next(context);
        }
    }
}
