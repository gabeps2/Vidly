using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(new MoviesViewModel(movies));
        }
        // GET: Movies/Details/5
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            foreach (var movie in _context.Movies.ToList())
            {
                if (movie.id == id)
                {
                    return View(movie);
                }
            }
            return View(new Movies() { id = -1 });
        }
    }
}
