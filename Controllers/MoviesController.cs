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

        private List<Movies> moviesList = new List<Movies>
        {
            new Movies(){name="Shrek!",id=1},
            new Movies(){name="Wall-e",id=2}
        };
        // GET: Movies
        [Route("Movies")]
        public ActionResult Movies()
        {
            var viewModel = new MoviesViewModel()
            {
                listMovies = this.moviesList,
            };
            return View(viewModel);
        }

        // GET: Movies/Details/5
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            foreach (var movie in moviesList)
            {
                if (movie.id == id)
                {
                    return View(movie);
                }
            }
            return View(new Movies() { id = -1 });
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
