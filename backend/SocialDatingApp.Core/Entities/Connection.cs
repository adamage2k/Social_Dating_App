using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Core.Entities
{
    public class Connection
    {
        public int ConnectionId { get; set; }
        public string UserId1 { get; set; }
        public virtual User User1 { get; set; }
        public string UserId2 { get; set; }
        public virtual User User2 { get; set; }
    }
}
