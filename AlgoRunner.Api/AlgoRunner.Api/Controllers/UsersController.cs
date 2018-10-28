using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
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
        public UsersController(IHttpContextAccessor accessor, UsersRepository repository)
        {
            _accessor = accessor;
            _repository = repository;
        }

        // GET: api/<controller>
        // [Authorize]
        [HttpGet]
        public ActionResult<User> Get()
        {
            string userName = _accessor.HttpContext.User.Identity.Name;
            var user = _repository.GetUserInfo(userName);

            if (user != null)
                return Ok(user);
            else
                return Ok(new User { Id = -1, Name = userName, IsAdmin = false });
        }

        [Authorize]
        [HttpGet("GetAdminInfo")]
        public ActionResult<AdminInfo> GetAdminInfo()
        {
            var members = _repository.GetAllMembers();
            var activities = _repository.GetAllActivities();
            return Ok(new AdminInfo { Members = members, Activities = activities });
        }

        [Authorize]
        [HttpGet("AddActivity/{name}")]
        public ActionResult<Activity> AddActivity(string name)
        {
            var activitiy = _repository.AddActivity(name);
            return Ok(activitiy);
        }

        [Authorize]
        [HttpPost("RemoveActivity")]
        public void RemoveActivity([FromBody]int id)
        {
            _repository.RemoveActivity(id);
        }

        private IHttpContextAccessor _accessor;
        private UsersRepository _repository;
    }
}
