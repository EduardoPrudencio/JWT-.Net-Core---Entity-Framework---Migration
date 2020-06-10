using AccessControl.BusinessRule.Models;
using AccessControl.Infrastructure;
using AccessControl.Infrastructure.Interfaces;
using AccessControl.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessControl.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<IdentityUser> _singnManager;
        private readonly UserManager<IdentityUser> _userManager;
        private AccessContext _context;

        public UserController(AccessContext context, SignInManager<IdentityUser> singnManager, UserManager<IdentityUser> userManager)
        {
            _singnManager = singnManager;
            _userManager = userManager;
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _userRepository.GetAll();
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user, [FromServices] AccessContext context)
        {
            var response = await context.User.AddAsync(user);
            await context.SaveChangesAsync();

            var identityUser = new IdentityUser
            {
                UserName = user.Name,
                Email = "teste@teste.com",
                EmailConfirmed = true,
            };

            string senha = "1001";

            var result = await _userManager.CreateAsync(identityUser, senha.ToString());

            if (!result.Succeeded) return BadRequest();



            return Ok(response.Entity);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
