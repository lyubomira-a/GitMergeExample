using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManager.Entities;
using MovieManager.Extensions;
using MovieManager.Models.Login;

namespace MovieManager.Controllers
{
    public class HomeController : Controller
    {
        private MovieManagerDbContext _context;

        public HomeController(MovieManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginVM model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                User loggedUser = _context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

                this.HttpContext.Session.SetObject("loggedUser", loggedUser);
            }
            if (this.HttpContext.Session.GetObject<User>("loggedUser") == null)
                return View(model);

            return RedirectToAction("Index");
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Index");
        }



        /*public static class AuthenticationService
    {
        public static User LoggedUser
        {
            get { return HttpContext.Current.Session.Get<User>("LoggedUser"); }
        }

        public static void Authenticate(string username, string password)
        {
            AccountService accountService = new AccountService();

            User loggedUser = accountService.GetUser(username, password).Result;

            if (loggedUser != null)
                HttpContext.Current.Session.Set("LoggedUser", loggedUser);
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Remove("LoggedUser");
        }
    }*/

    }
}
