using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManager.ActionFilters;
using MovieManager.Entities;
using MovieManager.Models;
using MovieManager.Models.Users;

namespace MovieManager.Controllers
{
    [Authentication]
    public class UsersController : Controller
    {
         private readonly MovieManagerDbContext _context;

         public UsersController(MovieManagerDbContext context)
         {
             _context = context;
         }
        public IActionResult Index()
        {
            IndexVM model = new IndexVM();
            model.Items = _context.Users.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            User user = id == null ?
                            new User() :
                            _context.Users.Where(u => u.Id == id.Value)
                                         .FirstOrDefault();

            if (user == null)
                return RedirectToAction("Index");

            EditVM model = new EditVM();
            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            if (item.Id <= 0)
                _context.Users.Add(item);
            else
                _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        public IActionResult Delete(int id)
        {

            User item = _context.Users.Where(u => u.Id == id)
                                     .FirstOrDefault();

            _context.Users.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }


        /*public IActionResult Index(IndexVM model)
        {
            UserService userService = new UserService();

            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Prefix = "Pager";

            model.Pager.Page = model.Pager.Page <= 0
                                ? 1
                                : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                            ? 10
                                            : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();

            var filter = model.Filter.GetFilter();

            model.Items = userService.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage).Result;
            model.Pager.PagesCount = (int)Math.Ceiling(
                                    userService.Count(filter) / (double)model.Pager.ItemsPerPage
                                );

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            UserService userService = new UserService();

            User item = id != null ? userService.GetById(id.Value).Result
                                   : new User();

            if (item == null)
                return RedirectToAction("Index");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.Email = item.Email;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.Email = model.Email;

            AccountService accountService = new AccountService();
            if (item.Id <= 0)
                accountService.RegisterUser(item, model.Password);
            else
                accountService.UpdateUser(item, model.Password);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UserService userService = new UserService();
            User item = userService.GetById(id).Result;

            if (item != null)
                userService.Delete(item);

            return RedirectToAction("Index");
        }*/
    }
}
