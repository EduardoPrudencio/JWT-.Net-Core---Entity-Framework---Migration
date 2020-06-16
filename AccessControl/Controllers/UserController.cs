using AccessControl.BusinessRule.Models;
using AccessControl.Configuration;
using AccessControl.Infrastructure;
using AccessControl.Infrastructure.Interfaces;
using AccessControl.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
        private AppSettings _appSettings;
        private AccessContext _context;

        public UserController(AccessContext context, SignInManager<IdentityUser> singnManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _singnManager = singnManager;
            _userManager = userManager;
            _context = context;
            _userRepository = new UserRepository(_context);
            _appSettings = appSettings.Value;
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


            string token = await GetToken(createUser.Email);

            var jwt = new TokenResponse(token);


            return Ok(jwt);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUser loginUser, [FromServices] AccessContext context)
        {
            var result = await _singnManager.PasswordSignInAsync(loginUser.Login.Trim(), loginUser.Password.Trim(), false, true);


            if (result.Succeeded)
            {
                string token = await GetToken(loginUser.Login);

                var jwt = new TokenResponse(token);

                return Ok(jwt);
            }

            return BadRequest();
        }

        private async Task<string> GetToken(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
