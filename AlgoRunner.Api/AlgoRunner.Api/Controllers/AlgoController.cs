﻿using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using AlgoRunner.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public AlgoController(ProjectsRepository projectsRepository, ActivityRepository activityRepository, AlgoExecutionService algoExecutionService, FilesService filesService)
        {
            _projectsRepository = projectsRepository;
            _activityRepository = activityRepository;
            _algoExecutionService = algoExecutionService;
            _filesService = filesService;
        }

        [HttpGet("{id}")]
        public ActionResult<Algorithm> Get(int id)
        {
            var alg = _projectsRepository.GetAlgorithm(id);
            return Ok(alg);
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Algorithm algo)
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
        public ActionResult CheckAccess([FromBody]int algId)
        {
            string path = _projectsRepository.GetAlgFilePath(algId);
            if (!_filesService.IsFolderAlowed(path))
                return Forbid();

            if (!System.IO.File.Exists(path))
                return NotFound();

            return Ok();
        }

        [HttpPost("RunAlgorithm")]
        public ActionResult RunAlgorithm([FromBody]Algorithm algo)
        {
            _algoExecutionService.Run(algo);
            return Ok();
        }


    }
}
