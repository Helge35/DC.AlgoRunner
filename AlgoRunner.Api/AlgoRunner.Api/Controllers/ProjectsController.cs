using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsRepository _repository;
        private readonly IMapper _mapper;
        private const int _projectPageSize = 12;
        private const int _algsPageSize = 14;        

        public ProjectsController(ProjectsRepository projectsRepository, IMapper mapper)
        {
            _repository = projectsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<DashboardInfoEntity> Get()
        {
            var dashboard = new DashboardInfoEntity();
            int projectsTotalSize = 0;
            int algsTotalSize = 0;
            dashboard.FavoriteList = _repository.GetFavoritesProjects().Select(x => _mapper.Map<ProjectEntity>(x));
            dashboard.ResentList = _repository.GetResentProjects().Select(x => _mapper.Map<ProjectEntity>(x));
            dashboard.AllList = _repository.GetProjectsByPage(1, _projectPageSize, out projectsTotalSize).Select(x => _mapper.Map<ProjectEntity>(x));
            dashboard.ProjectsTotalSize = projectsTotalSize;
            dashboard.AlgorithmsList = _repository.GetAlgsByPage(1, _algsPageSize, out algsTotalSize).Select(x => _mapper.Map<AlgorithmEntity>(x)).ToList();
            dashboard.AlgorithmsTotalSize = algsTotalSize;
            dashboard.ExecutionInfoList = _repository.GetExecutions().Select(x => _mapper.Map<ExecutionInfoEntity>(x));
            return Ok(dashboard);
        }

       
        [HttpGet("{id}")]
        public ActionResult<ProjectEntity> Get(int id)
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
        public ActionResult<DashboardInfoEntity> LoadProjects(int page)
        {
            var dashboard = new DashboardInfoEntity();
            int totalSize = 0;
            dashboard.AllList = _repository.GetProjectsByPage(page, _projectPageSize, out totalSize);
            dashboard.ProjectsTotalSize = totalSize;
            return Ok(dashboard);
        }

        [HttpGet("LoadAlgs/{page}")]
        public ActionResult<DashboardInfoEntity> LoadAlgs(int page)
        {
            var dashboard = new DashboardInfoEntity();
            int totalSize = 0;
            dashboard.AlgorithmsList = _repository.GetAlgsByPage(page, _algsPageSize, out totalSize);
            dashboard.AlgorithmsTotalSize = totalSize;
            return Ok(dashboard);
        }

        [HttpGet("LoadAllAlgs")]
        public ActionResult<AlgorithmEntity> LoadAllAlgs()
        {
            var list =_repository.GetAllAlgs();
            return Ok(list);
        }

        [HttpPost("ExeciteProject")]
        public ActionResult ExeciteProject()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody]ProjectEntity proj)
        {
            _repository.AddNewProject(proj);
            return Ok();
        }
    }
}
