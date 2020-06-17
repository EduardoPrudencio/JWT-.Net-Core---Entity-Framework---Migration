using AccessControl.BusinessRule.Models;
using AccessControl.Configuration;
using AccessControl.Infrastructure;
using AccessControl.Infrastructure.Interfaces;
using AccessControl.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Controllers
{
    [Authorize]
    [Route("api/services")]
    [ApiController]
    public class ServiceController : MainController
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(AccessContext context, AuthenticatedUser user) : base(user)
        {
            _serviceRepository = new ServiceRepository(context);
        }


        // GET: api/Service
        [ClaimsAuthorize("Services", "Consultar")]
        [HttpGet]
        public async Task<List<Service>> Get()
        {
            return await _serviceRepository.GetAll();
        }

        // GET: api/Service/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Service
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
