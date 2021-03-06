﻿using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<ActivityEntity>> Get()
        {
            return Ok(_repository.GetAllActivities());
        }

        [HttpPost]
        public ActionResult<ActivityEntity> Post(ActivityEntity newActivity)
        {
            var activitiy = _repository.AddActivity( newActivity);
            return Ok(activitiy);
        }

        [HttpPost("RemoveActivity")]
        public void RemoveActivity([FromBody]int id)
        {
            _repository.RemoveActivity(id);
        }

        [HttpPost("SaveCommonPath")]
        public void SaveCommonPath(ActivityEntity common)
        {
            _repository.UpdateCommonPath(common.ServerPath);
        }


    }
}
