using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API.Repository;
using API.Models;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private readonly MovieManagerDbContext _context;

        public UsersController(MovieManagerDbContext context)
        {
            _context = context;
        }     

        [HttpGet]
        public IActionResult GetAll()
        {
            IndexVM model = new IndexVM();
            model.Items = _context.Users.ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var item = _context.Users.Find(id);
            
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(UserVM model)
        {
             User user = new User();
             user.Id = model.Id;
             user.Username = model.Username;
             user.Password = model.Password;
             user.FirstName = model.FirstName;
             user.LastName = model.LastName;

            _context.Users.Add(user);

            _context.SaveChanges();

            return Created("", user);
        }

        [HttpPut]
        public IActionResult Update(UserVM model)
        {
            User user = new User();
            user.Id = model.Id;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            _context.Entry(user).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();                
            }
        }
    }
}
