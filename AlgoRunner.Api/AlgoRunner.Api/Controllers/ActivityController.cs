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
        public ActionResult<List<Activity>> Get()
        {
            return Ok(_repository.GetAllActivities());
        }

        [HttpPost]
        public ActionResult<Activity> Post(Activity newActivity)
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
        public void SaveCommonPath(Activity common)
        {
            _repository.UpdateCommonPath(common.ServerPath);
        }


    }
}