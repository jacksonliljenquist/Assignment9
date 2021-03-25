using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IFilmRepository _repository;

        private FilmListDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, IFilmRepository repository, FilmListDbContext con)
        {
            _logger = logger;
            _repository = repository;
            _context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(FilmInfo filmInput)
        {
            if (ModelState.IsValid)
            {
                _context.FilmInfo.Add(filmInput);
                _context.SaveChanges();
                return View("Confirmation");
            }
            return View(filmInput);
            
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(_repository.FilmInfo);
        }

        public IActionResult Delete(int id)
        {
            //x = each individual FilmInfo where x has x.FilmID == id
            FilmInfo itemRemove = _context.FilmInfo.Where(x => x.FilmID == id).FirstOrDefault();
            _context.FilmInfo.Remove(itemRemove);
            _context.SaveChanges();
            return RedirectToAction("Confirmation");
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            FilmInfo itemUpdate = _context.FilmInfo.Where(x => x.FilmID == id).FirstOrDefault();
            return View(itemUpdate);
        }
        [HttpPost]
        public IActionResult Update (FilmInfo updatedObj)
        {
            if (ModelState.IsValid)
            {
                FilmInfo itemUpdate = _context.FilmInfo.Where(x => x.FilmID == updatedObj.FilmID).FirstOrDefault();
                itemUpdate.Category = updatedObj.Category;
                itemUpdate.Title = updatedObj.Title;
                itemUpdate.Year = updatedObj.Year;
                itemUpdate.Director = updatedObj.Director;
                itemUpdate.Rating = updatedObj.Rating;
                itemUpdate.Edited = updatedObj.Edited;
                itemUpdate.LentTo = updatedObj.LentTo;
                itemUpdate.Notes = updatedObj.Notes;
                _context.SaveChanges();
                return View("Confirmation");
            }

            return View(updatedObj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
