using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager;
using MovieManager.ActionFilters;
using MovieManager.Entities;
using MovieManager.Models.Movies;

namespace MovieManager.Controllers
{
    [Authentication]
    public class MoviesController : Controller
    {
        private readonly MovieManagerDbContext _context;

        public MoviesController(MovieManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IndexVM model = new IndexVM();
            model.Items = _context.Movies.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit (int? id)
        {
            Movie movie = id == null ?
                new Movie() : _context.Movies.Where(u => u.Id == id.Value)
                .FirstOrDefault();

            if (movie == null)
                return RedirectToAction("Index");

            EditVM model = new EditVM();
            model.Id = movie.Id;
            model.Name = movie.Name;
            model.Producer = movie.Producer;
            model.Rating = movie.Rating;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Movie item = new Movie();
            item.Id = model.Id;
            item.Name = model.Name;
            item.Producer = model.Producer;
            item.Rating = model.Rating;

            if (item.Id <= 0)
                _context.Movies.Add(item);
            else
                _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Delete(int id)
        {
            Movie item = _context.Movies.Where(m => m.Id == id)
                .FirstOrDefault();

            _context.Movies.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
