using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() //all users
        {
            return Ok(new List<User>() {
                new User() { Id = 1, Username = "nikiv", Password = "nikipass", FirstName = "Nikola", LastName = "Valchanov" },
                new User() { Id = 2, Username = "mikiv", Password = "mikipass", FirstName = "Mikola", LastName = "Malchanov" },
                new User() { Id = 3, Username = "fikiv", Password = "fikipass", FirstName = "Fikola", LastName = "Falchanov" }
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) // concrete user
        {
            return Ok(new User() { Id = 1, Username = "nikiv", Password = "nikipass", FirstName = "Nikola", LastName = "Valchanov" });
        }

        [HttpPost]
        //create metod - for the CRUD operations - must have ViewModel
        public IActionResult Post([FromBody] User item)
        {
            return Created ("", item);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
