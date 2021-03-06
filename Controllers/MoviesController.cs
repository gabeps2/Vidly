﻿using System;
using System.Data.Entity.Validation;
using System.Linq;
using Vidly2.Models.IdentityModels;
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel(movie)
            {
                id = movie.id,
                name = movie.name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies
        [Route("Movies")]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        // GET: Movies/Details/5
        [Authorize(Roles = RoleName.CanManageMovies)]
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
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movies movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    id = movie.id,
                    name = movie.name,
                    NumberInStock = movie.NumberInStock,
                    ReleaseDate = movie.ReleaseDate,
                    GenreId = movie.GenreId,
                    Genres = _context.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            }

            if (movie.id == 0)
            {
                movie.DateAdded = DateTime.Now;
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
