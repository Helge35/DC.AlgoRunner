using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private FilesService _filesService;
        private ProjectsRepository _projectsRepository;
        private IHttpContextAccessor _accessor;

        public ResultsController(FilesService filesService, ProjectsRepository projectsRepository, IHttpContextAccessor accessor)
        {
            _filesService = filesService;
            _projectsRepository = projectsRepository;
            _accessor = accessor;
        }


        [HttpGet("{path}")]
        public ActionResult<List<IAlgoResultEntity>> Get(string path)
        {
            try
            {
                var pathVar = path.Split('_');
                int exeID;
                int projectID;
                List<AlgorithmEntity> algos = new List<AlgorithmEntity>();
                path = _filesService.GetFullPath(path);

                if (!System.IO.Directory.Exists(path))
                    return NotFound();

                if (pathVar.Length != 2 || !int.TryParse(pathVar[1], out exeID) || !int.TryParse(pathVar[0], out projectID))
                    return NotFound();

                if (!_filesService.IsFolderAllowed(path, _accessor.HttpContext.User.Identity.Name))
                    return Forbid();

                if (projectID > 0)
                    algos = _projectsRepository.GetAlgorithmsByExecution(exeID);
                else
                    algos.Add(_projectsRepository.GetAlgorithmByAlgoExeId(exeID));

                List<IAlgoResultEntity> results = ResultsFactory.GetResults(algos, path);

                return Ok(results);
            }
            catch(FileNotFoundException exp) { return NotFound(); }
        }
    }
}
