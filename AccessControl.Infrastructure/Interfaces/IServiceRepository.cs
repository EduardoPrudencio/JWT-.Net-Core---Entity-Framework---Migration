using AccessControl.BusinessRule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Infrastructure.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
    }
}
