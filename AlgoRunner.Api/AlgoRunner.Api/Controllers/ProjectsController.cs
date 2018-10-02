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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private ProjectsRepository _repository;
        private const int _projectPageSize = 8;

        public ProjectsController(ProjectsRepository projectsRepository)
        {
            _repository = projectsRepository;
        }

        [HttpGet]
        public ActionResult<DashboardInfo> Get()
        {
            var dashboard = new DashboardInfo();
            int totalSize = 0;
            dashboard.FavoriteList = _repository.GetFavoritesProjects();
            dashboard.ResentList = _repository.GetResentProjects();
            dashboard.AllList = _repository.GetProjectsByPage(1, _projectPageSize, out totalSize);
            dashboard.TotalSize = totalSize;
            return Ok(dashboard);
        }

        [HttpGet("AddToFavorite/{id}")]
        public ActionResult<bool> AddToFavorite(int id)
        {
            _repository.AddToFavorite(id);
            return Ok(true);
        }

        [HttpGet("LoadProjects/{page}")]
        public ActionResult<DashboardInfo> LoadProjects(int page)
        {
            var dashboard = new DashboardInfo();
            int totalSize = 0;
            dashboard.AllList = _repository.GetProjectsByPage(page, _projectPageSize, out totalSize);
            dashboard.TotalSize = totalSize;
            return Ok(dashboard);
        }

        [HttpGet("GetProject/{id}")]
        public ActionResult<Project> GetProject(int id)
        {
           var project = _repository.GetProject(id);
            return Ok(project);
        }
    }
}
