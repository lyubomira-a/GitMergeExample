using API.Models.Movies;
using System.Linq;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MovieController : Controller
    {
        private readonly MovieManagerDbContext _context;

        public MovieController(MovieManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IndexVM model = new IndexVM();
            model.Items = _context.Movies.ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Movies.Find(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(EditVM model)
        {
            Movie movie = new Movie();
            movie.Id = model.Id;
            movie.Name = model.Name;
            movie.Producer = model.Producer;
            movie.Rating = model.Rating;

            _context.Movies.Add(movie);

            _context.SaveChanges();

            return Created("", movie);
        }

        [HttpPut]
        public IActionResult Update(EditVM model)
        {
            Movie movie = new Movie();
            movie.Id = model.Id;
            movie.Name = model.Name;
            movie.Producer = model.Producer;
            movie.Rating = model.Rating;

            _context.Entry(movie).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

    }
}
