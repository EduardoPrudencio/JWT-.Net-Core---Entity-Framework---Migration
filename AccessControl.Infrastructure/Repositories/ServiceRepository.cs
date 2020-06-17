using AccessControl.BusinessRule.Models;
using AccessControl.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AccessContext _context;

        public ServiceRepository(AccessContext context)
        {
            this._context = context;
        }

        public async Task<List<Service>> GetAll()
        {
            var listOfServices = await _context.Service.ToListAsync();
            return listOfServices;
        }
    }
}
