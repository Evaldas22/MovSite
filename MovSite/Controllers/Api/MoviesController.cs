using AutoMapper;
using MovSite.DTOs;
using MovSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MovSite.Controllers.Api
{
    [Authorize]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: /api/Movies/GetMoviesNotSeen
        [HttpGet]
        [Route("api/Movies/GetMoviesNotSeen/{userId}")]
        public IEnumerable<MovieDto> GetMoviesNotSeen(string userId)
        {
            return _dbContext.Movies.Where(m => m.Seen == false && m.UserID == userId).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        [HttpGet]
        [Route("api/Movies/GetMoviesSeen/{userId}")]
        public IEnumerable<MovieDto> GetMoviesSeen(string userId)
        {
            return _dbContext.Movies.Where(m => m.Seen == true && m.UserID == userId).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //// GET: /api/Movies/GetMovies
        //[HttpGet]
        //[Route("api/Movies/GetMovies")]
        //public IEnumerable<MovieDto> GetMovies()
        //{
        //    return _dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        //}

        //// GET: /api/Movies/{id}
        //[HttpGet]
        //public MovieDto GetMovie(int id)
        //{
        //    var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

        //    if (movie == null) throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map< Movie, MovieDto>(movie);
        //}
        
        // POST: /api/Movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid || movieDto == null) return BadRequest();

            if (_dbContext.Movies.Any(m => m.Name == movieDto.Name)) BadRequest();

            _dbContext.Movies.Add(Mapper.Map<MovieDto, Movie>(movieDto));
            _dbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        // PUT: /api/Movie/{id}
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) BadRequest();

            Movie movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null) BadRequest();

            Mapper.Map(movieDto, movieInDb);

            _dbContext.SaveChanges();

            return Ok();
        }

        // DELETE: /api/Movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null) NotFound();

            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
