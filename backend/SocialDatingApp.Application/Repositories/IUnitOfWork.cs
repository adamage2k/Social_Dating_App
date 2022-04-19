using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Repositories
{
    public interface IUnitOfWork
    {
        IConnectionRepository ConnectionRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
