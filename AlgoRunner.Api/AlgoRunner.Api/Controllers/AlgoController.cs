using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlgoController : ControllerBase
    {
        private ProjectsRepository _projectsRepository;
        private IHostingEnvironment _hostingEnvironment;
        private ActivityRepository _activityRepository;

        public AlgoController(ProjectsRepository projectsRepository, ActivityRepository activityRepository, IHostingEnvironment hostingEnvironment)
        {
            _projectsRepository = projectsRepository;
            _hostingEnvironment = hostingEnvironment;
            _activityRepository = activityRepository;
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
                    fileName = Guid.NewGuid().ToString().Replace("-", string.Empty).Trim() + "." + file.FileName.Split('.')[1];
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
    }
}
