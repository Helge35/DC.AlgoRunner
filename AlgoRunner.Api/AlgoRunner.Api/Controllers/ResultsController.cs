using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private FilesService _filesService;
        private ProjectsRepository _projectsRepository;

        public ResultsController(FilesService filesService, ProjectsRepository projectsRepository)
        {
            _filesService = filesService;
            _projectsRepository = projectsRepository;
        }


        [HttpGet("{path}")]
        public ActionResult<List<IAlgoResultEntity>> Get(string path)
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

            if (!_filesService.IsFolderAlowed(path))
                return Forbid();

            if (projectID > 0)
                algos = _projectsRepository.GetAlgorithmsByExecution(exeID);
            else
                algos.Add(_projectsRepository.GetAlgorithmByAlgoExeId(exeID));

            List<IAlgoResultEntity> results = ResultsFactory.GetResults(algos, path);

            return Ok(results);
        }
    }
}
