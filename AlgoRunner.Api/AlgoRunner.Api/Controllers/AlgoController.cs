using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlgoController : ControllerBase
    {
        private ProjectsRepository _projectsRepository;
        private ActivityRepository _activityRepository;
        private AlgoExecutionService _algoExecutionService;
        private FilesService _filesService;
        private IHttpContextAccessor _accessor;

        public AlgoController(ProjectsRepository projectsRepository, ActivityRepository activityRepository, AlgoExecutionService algoExecutionService, FilesService filesService, IHttpContextAccessor accessor)
        {
            _projectsRepository = projectsRepository;
            _activityRepository = activityRepository;
            _algoExecutionService = algoExecutionService;
            _filesService = filesService;
            _accessor = accessor;
        }

        [HttpGet("{projectId}/{id}")]
        public ActionResult<List<AlgorithmEntity>> Get(int projectId, int id)
        {
            if (projectId > 0)
            {
                return Ok(_projectsRepository.GetProjectAlgorithms(projectId));
            }
            if (id > 0)
            {
                var algs = new List<AlgorithmEntity>();
                algs.Add(_projectsRepository.GetAlgorithm(id));
                return Ok(algs);
            }

            return BadRequest();
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] AlgorithmEntity algo)
        {
            _projectsRepository.AddNewAlg(algo);
            return Ok(true);
        }

        [HttpPost("UploadFile"), DisableRequestSizeLimit]
        public ActionResult<string> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string activityID = Request.Form.Keys.First();
                string fullPath = string.Empty;
                string fileName = string.Empty;
                string newPath = _activityRepository.GetActivityPath(int.Parse(activityID));
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                if (file.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split('.')[1];
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok(fileName);
            }
            catch (System.Exception ex)
            {
                return BadRequest("Upload Failed: " + ex.Message);
            }
        }

        [HttpPost("CheckAccess")]
        public ActionResult CheckAccess([FromBody]ProjectAlgoEntity projectAlgo)
        {
            string[] paths = _projectsRepository.GetAlgFilePath(projectAlgo);
            foreach (var path in paths)
            {
                if (!_filesService.IsFolderAlowed(path))
                    return Forbid();

                if (!System.IO.File.Exists(path))
                    return NotFound();
            }

            return Ok();
        }

        [HttpPost("RunAlgorithms")]
        public ActionResult RunAlgorithms([FromBody]ProjectAlgoListEntity data)
        {
            string userName = _accessor.HttpContext.User.Identity.Name;
            _algoExecutionService.Run(data, userName);
            return Ok();
        }
    }
}
