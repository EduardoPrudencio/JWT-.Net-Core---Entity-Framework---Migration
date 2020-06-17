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
            var listOfUsers = await _context.User.ToListAsync();
            return listOfUsers;
        }

        public async Task<User> GetById(string id)
        {
            var users = await _context.User.FirstOrDefaultAsync(u => u.Id.Equals(id.Trim()));
            return users;
        }

    }
}
