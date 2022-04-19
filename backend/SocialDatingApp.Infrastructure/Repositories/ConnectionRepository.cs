using SocialDatingApp.Application.Repositories;
using SocialDatingApp.Application.Users.DTOs;
using SocialDatingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
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

        public Task<UserDTO> GetAllMatches(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
