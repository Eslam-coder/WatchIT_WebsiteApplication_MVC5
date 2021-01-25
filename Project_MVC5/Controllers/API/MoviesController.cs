using Project_MVC5.DTO;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace Project_MVC5.Controllers.API
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        //Get /api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GetById /api/Movies/I
        public IHttpActionResult GetMovieById (int id)
        {
           Movie MovieInDb = context.Movies.FirstOrDefault(m => m.ID == id);
            if (MovieInDb == null)
                return NotFound();
           
            return Ok(Mapper.Map<Movie, MovieDto>(MovieInDb));
        }

        //Post /api/Movies/Create
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto NewMovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie NewMovie = Mapper.Map<MovieDto, Movie>(NewMovieDto);
            //var NewMovie =  Mapper.Map<Movie>(NewMovieDto);
            context.Movies.Add(NewMovie);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + NewMovie.ID), NewMovieDto);
        }

        //Put /api/Movies/UpdateMovie
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id , MovieDto UpdateMovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie MovieInDb = context.Movies.Find(id);
            if (MovieInDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(UpdateMovieDto, MovieInDb);
            context.SaveChanges();
            return Ok();
        }

        //Delete /api/Movies/RemoveMovie
        [HttpDelete]
        public IHttpActionResult RemoveMovie(int id)
        {
            Movie MovieInDb = context.Movies.Find(id);

            if (MovieInDb == null)
                return NotFound();
            context.Movies.Remove(MovieInDb);
            context.SaveChanges();
            return Ok();
        }

    }
}
