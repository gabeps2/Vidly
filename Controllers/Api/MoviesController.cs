using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Vidly2.Dtos;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movies.Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movies, MoviesDto>);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)

                return NotFound();

            return Ok(Mapper.Map<Movies, MoviesDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDto, Movies>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.id = movie.id;

            return Created(new Uri(Request.RequestUri + "/" + movie.id), movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
                return NotFound();

            movieDto.id = movieInDb.id;

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/movies/1
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
