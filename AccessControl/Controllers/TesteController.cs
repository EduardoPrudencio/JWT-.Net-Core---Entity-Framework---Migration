using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AccessControl.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        // GET: api/Teste
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Teste/5
        //[HttpGet("{id}", Name = "Get")]
        //public int Get(int id)
        //{
        //    return 10;
        //}

        // POST: api/Teste
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Teste/5
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
