using AccessControl.BusinessRule.Models;
using AccessControl.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccessContext _context;

        public UserRepository(AccessContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

    }
}
