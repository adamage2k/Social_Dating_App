using Microsoft.AspNetCore.Identity;
using SocialDatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Core
{
    public class User : IdentityUser
    {
        public static string FistName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Connection> Sent { get; set; }

        public virtual ICollection<Connection> Received { get; set; }
    }
}
