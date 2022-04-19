using SocialDatingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Helpers
{
    public interface IJwtTokenService
    {
        string CreateToken(User user);
    }
}
