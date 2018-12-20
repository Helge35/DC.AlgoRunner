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
        private const int _projectPageSize = 12;
        private const int _algsPageSize = 16;

        public ProjectsController(ProjectsRepository projectsRepository)
        {
            _repository = projectsRepository;
        }

        [HttpGet]
        public ActionResult<DashboardInfo> Get()
        {
            var dashboard = new DashboardInfo();
            int projectsTotalSize = 0;
            int algsTotalSize = 0;
            dashboard.FavoriteList = _repository.GetFavoritesProjects();
            dashboard.ResentList = _repository.GetResentProjects();
            dashboard.AllList = _repository.GetProjectsByPage(1, _projectPageSize, out projectsTotalSize);
            dashboard.ProjectsTotalSize = projectsTotalSize;
            dashboard.AlgorithmsList = _repository.GetAlgsByPage(1, _algsPageSize, out algsTotalSize);
            dashboard.AlgorithmsTotalSize = algsTotalSize;
            return Ok(dashboard);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = _repository.GetProject(id);
            return Ok(project);
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
            dashboard.ProjectsTotalSize = totalSize;
            return Ok(dashboard);
        }

        [HttpGet("LoadAlgs/{page}")]
        public ActionResult<DashboardInfo> LoadAlgs(int page)
        {
            var dashboard = new DashboardInfo();
            int totalSize = 0;
            dashboard.AlgorithmsList = _repository.GetAlgsByPage(page, _algsPageSize, out totalSize);
            dashboard.AlgorithmsTotalSize = totalSize;
            return Ok(dashboard);
        }
    }
}
