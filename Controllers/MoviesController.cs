using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Movies = movies,
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.ToList();

            foreach (var movie in _context.Movies.ToList())
            {
                if (movie.id == id)
                {
                    var viewModel1 = new MoviesFormViewModel
                    {
                        Movie = movie,
                        Movies = movies,
                    };
                    return View("MovieForm", viewModel1);
                }

            }
            var viewModel = new MoviesFormViewModel
            {
                Movies = movies,
            };
            return View("MovieForm", viewModel);
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

        [HttpPost]
        public ActionResult Save(Movies movie)
        {
            if (movie.id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.id == movie.id);
                movieInDb.name = movie.name;
                movieInDb.Genre = movie.Genre;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Movies");
        }
    }
}
