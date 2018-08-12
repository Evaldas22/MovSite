using AutoMapper;
using MovSite.DTOs;
using MovSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace MovSite.Controllers.Api
{
    [Authorize]
    public class TVShowsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public TVShowsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //
        // Summary:
        //     I don't want to expose this functionality yet

        //// GET: /api/TVShows
        //[HttpGet]
        //public IEnumerable<TVShowDto> GetTVShows()
        //{
        //    return _dbContext.TVShows.ToList().Select(Mapper.Map<TVShow, TVShowDto>);
        //}

        //// GET: /api/TVShows/{id}
        //[HttpGet]
        //public TVShowDto GetTVShow(int id)
        //{
        //    var tvShow = _dbContext.TVShows.SingleOrDefault(t => t.Id == id);

        //    if (tvShow == null) throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map<TVShow, TVShowDto>(tvShow);
        //}

        //// POST: /api/TVShows
        //[HttpPost]
        //public IHttpActionResult CreateTVShow(TVShowDto tvShowDto)
        //{
        //    if (!ModelState.IsValid || tvShowDto == null) BadRequest();

        //    if (_dbContext.TVShows.Any(t => t.Name == tvShowDto.Name)) BadRequest();

        //    _dbContext.TVShows.Add(Mapper.Map<TVShowDto, TVShow>(tvShowDto));
        //    _dbContext.SaveChanges();

        //    return Created(new Uri(Request.RequestUri + "/" + tvShowDto.Id), tvShowDto);
        //}

        //// PUT: /api/TVShows/{id}
        //[HttpPut]
        //public IHttpActionResult UpdateTVShow(int id, TVShowDto tvShowDto)
        //{
        //    if (!ModelState.IsValid) BadRequest();

        //    TVShow tvShowInDb = _dbContext.TVShows.SingleOrDefault(t => t.Id == id);

        //    if (tvShowInDb == null) BadRequest();

        //    Mapper.Map(tvShowDto, tvShowInDb);

        //    _dbContext.SaveChanges();

        //    return Ok();
        //}

        //// DELETE: /api/TVShows/{id}
        //[HttpDelete]
        //public IHttpActionResult DeleteTVShow(int id)
        //{
        //    TVShow tvShowInDb = _dbContext.TVShows.SingleOrDefault(t => t.Id == id);

        //    if (tvShowInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _dbContext.TVShows.Remove(tvShowInDb);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
