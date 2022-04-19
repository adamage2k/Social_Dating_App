using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialDatingApp.Application.Helpers;
using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Helpers
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly SymmetricSecurityKey _key;

        public JwtTokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
        }

        public string CreateToken(User user)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var expirationDate = DateTime.Now.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
