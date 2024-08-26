using Application.Interfaces.AppUserInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<AppRole> GetRoleByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            var value = await _context.roles.Where(filter).FirstOrDefaultAsync();
            return value;
        }

        public async Task<AppUser> GetUserByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var value = await _context.users.Where(filter).FirstOrDefaultAsync();
            return value;
        }
    }
}
