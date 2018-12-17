using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        MessagesRepository _repository;
        IHttpContextAccessor _accessor;

        public MessagesController(MessagesRepository repository, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            string userName = _accessor.HttpContext.User.Identity.Name;
            return _repository.GetMessages(userName);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteMessage(id);
        }


        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
