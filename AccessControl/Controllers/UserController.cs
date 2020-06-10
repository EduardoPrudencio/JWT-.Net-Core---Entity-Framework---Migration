using AccessControl.BusinessRule.Models;
using AccessControl.Infrastructure;
using AccessControl.Infrastructure.Interfaces;
using AccessControl.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        public async Task<ActionResult<User>> Post([FromBody] CreateUser createUser, [FromServices] AccessContext context)
        {
            User user = new User
            {
                Name = createUser.Name,
                LastName = createUser.LastName,
                BirthDate = createUser.BirthDate
            };

            var response = await context.User.AddAsync(user);


            var identityUser = new IdentityUser
            {
                Id = user.Id,
                UserName = createUser.Email.Trim(),
                Email = createUser.Email.Trim(),
                EmailConfirmed = true,
            };


            var result = await _userManager.CreateAsync(identityUser, createUser.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await context.SaveChangesAsync();

            return Ok(response.Entity);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUser loginUser, [FromServices] AccessContext context)
        {
            var result = await _singnManager.PasswordSignInAsync(loginUser.Login.Trim(), loginUser.password.Trim(), false, true);

            if (result.Succeeded)
                return Ok();

            return BadRequest();


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
