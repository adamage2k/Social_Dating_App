using Microsoft.EntityFrameworkCore;
using SocialDatingApp.Application.Repositories;
using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Core.Entities;
using SocialDatingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly ApplicationDbContext _context;
        public ConnectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllMatchesAsync(string userId)
        {
            var connections = await _context.Set<Connection>().ToListAsync();
            var matches = connections.Where(x => x.UserId1 == userId).Select(x => x.User2).ToList();
            var matches2 = connections.Where(x => x.UserId2 == userId ).Select(x => x.User1).ToList();

            matches.AddRange(matches2);

            var result = new List<UserDTO>();
            foreach(var match in matches)
            {
                var user = new UserDTO();
                user.UserName = match.UserName;
                user.FirstName = match.FirstName;
                user.LastName = match.LastName;
                user.KnownAs = string.Format("{0} {1}", match.FirstName, match.LastName);
                user.Email = match.Email;

                byte[] bytes = File.ReadAllBytes("Photos/" + user.UserName + ".png");
                user.Photo = Convert.ToBase64String(bytes);

                result.Add(user);
            }

            return result;
            
            
        }
    }
}
