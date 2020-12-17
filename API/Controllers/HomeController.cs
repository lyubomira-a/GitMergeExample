using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly MovieManagerDbContext _context;

        public HomeController(MovieManagerDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthLogin model)
        {
           if(!ModelState.IsValid)
                return BadRequest(new {
                    message = "fail"
                });

            var user = _context.Users
                .SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
                return NotFound();

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Tokens:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(_config["Tokens:ExpirationPeriod"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token) });
            }

            return BadRequest("Could not create token");

        }
    }
}
