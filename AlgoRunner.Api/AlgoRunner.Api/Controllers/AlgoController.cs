using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlgoController : ControllerBase
    {
        private ProjectsRepository _projectsRepository;

        public AlgoController(ProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Algorithm algo)
        {
            _projectsRepository.AddNewAlg(algo);
            return Ok(true);
        }
    }
}
