using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgoRunner.Api.Dal;
using AlgoRunner.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlgoRunner.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        MessagesRepository _repository;

        public MessagesController(MessagesRepository repository)
        {
            _repository = repository;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Message> Get(int id)
        {
            return _repository.GetMessages(id);
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
