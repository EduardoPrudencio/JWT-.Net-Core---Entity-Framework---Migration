using AccessControl.BusinessRule.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private AuthenticatedUser _user;

        public MainController(AuthenticatedUser user)
        {
            _user = user;
        }

        protected AuthenticatedUser LogedUser { get { return _user; } }

    }
}