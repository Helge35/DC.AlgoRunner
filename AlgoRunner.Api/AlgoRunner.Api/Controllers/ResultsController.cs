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
                path = _filesService.GetFullPath(path);

                if (!Directory.Exists(path))
                    return NotFound();

                if (pathVar.Length != 2 || !int.TryParse(pathVar[1], out int exeID) || !int.TryParse(pathVar[0], out int projectID))
                    return NotFound();

                if (!_filesService.IsFolderAllowed(path, _accessor.HttpContext.User.Identity.Name))
                    return Forbid();

                return Ok(ResultsFactory.GetResults(_projectsRepository.GetAlgorithmsByExecution(exeID), path));
            }
            catch (FileNotFoundException) { return NotFound(); }
        }
    }
}
