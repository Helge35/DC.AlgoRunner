using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AlgoRunner.Api.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public ActionResult<string> Get()
        {
            string userName = _accessor.HttpContext.User.Identity.Name;
            return userName;
        }

        private IHttpContextAccessor _accessor;
    }
}
