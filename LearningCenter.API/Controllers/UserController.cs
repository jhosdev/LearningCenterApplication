using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCenter.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Injection
        private IUserInfrastructure _userInfrastructure;

        public UserController(IUserInfrastructure userInfrastructure)
        {
            _userInfrastructure = userInfrastructure;
        }
        
        // GET: api/User
        [HttpGet(Name = "GetUsers")]
        public IEnumerable<string> Get()
        {
            return _userInfrastructure.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
