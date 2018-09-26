using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AlgoRunner.Api.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private ProjectsRepository _repository;

        public ProjectsController(ProjectsRepository projectsRepository)
        {
            _repository = projectsRepository;
        }

        [HttpGet]
        public ActionResult<DashboardInfo> Get()
        {
            var dashboard = new DashboardInfo();
            dashboard.FavoriteList = _repository.GetFavoritesProjects();
            dashboard.ResentList = _repository.GetResentProjects();
            dashboard.AllList = _repository.GetProjectsByPage(1,8);
            return Ok(dashboard);
        }
    }
}
