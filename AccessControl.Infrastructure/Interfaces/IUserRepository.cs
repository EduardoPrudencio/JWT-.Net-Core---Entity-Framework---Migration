using AccessControl.BusinessRule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
    }
}
