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
            var genres = _context.Genres.ToList();
            var movie = new Movies();
            var viewModel = new MoviesFormViewModel
            {
                Genres = genres,
                Movie = movie,
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();

            foreach (var movie in _context.Movies.ToList())
            {
                if (movie.id == id)
                {
                    var viewModel1 = new MoviesFormViewModel
                    {
                        Movie = movie,
                        Genres = genres,
                    };
                    return View("MovieForm", viewModel1);
                }

            }
            var viewModel = new MoviesFormViewModel
            {
                Genres = genres,
            };
            return View("MovieForm", viewModel);
        }

        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var genres = _context.Genres.ToList();
            return View(new MoviesViewModel { Genres = genres, Movies = movies});
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            }

            if (movie.id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.id == movie.id);
                movieInDb.name = movie.name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Movies");
        }
    }
}
