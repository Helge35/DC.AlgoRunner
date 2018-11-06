using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController: ControllerBase
    {
        private ActivityRepository _repository;

        public ActivityController(ActivityRepository activityRepository)
        {
            _repository = activityRepository;
        }

        [HttpGet]
        public ActionResult<List<Activity>> Get()
        {
            return Ok(_repository.GetAllActivities());
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
    }
}
