using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUserByFilterAsync(Expression<Func<AppUser, bool>> filter);
        Task<AppRole> GetRoleByFilterAsync(Expression<Func<AppRole, bool>> filter);
    }
}
