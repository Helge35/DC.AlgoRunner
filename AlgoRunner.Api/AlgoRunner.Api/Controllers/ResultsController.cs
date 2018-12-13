using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<AlgoDotesResult>Get(string path)
        {
            var pathVar = path.Split('_');
            int algoID;
            if (pathVar.Length != 2 || !int.TryParse(pathVar[0], out algoID))
                return NotFound();

            path = _filesService.GetFullPath(path);
            if (!_filesService.IsFolderAlowed(path))
                return Forbid();

            if (!System.IO.File.Exists(path))
                return NotFound();

            AlgoDotesResult result = new AlgoDotesResult();
            result.ReadDataFromFile(path);
            result.AlgoName = _projectsRepository.GetAlgorithm(algoID).Name;

            return Ok(result);
        }
    }
}
