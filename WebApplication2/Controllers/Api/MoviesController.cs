using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using System.Data.Entity;
using System.Web.Http;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                             .Include(m => m.Genre)
                             .Where(m => m.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));
            var movieDtos = movieQuery
                            .ToList()
                            .Select(Mapper.Map<Movie,MovieDto>);
            return Ok(movieDtos);
        }
        public IHttpActionResult GetMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }
        [HttpPost]
        // Create a new Movie
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        //update movie
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return BadRequest();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
       

    }
}
