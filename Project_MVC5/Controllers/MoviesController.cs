using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Authorize]
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole("canManageMovies"))
            {
                var movie = context.Movies.ToList();
                return View(movie);
            }
            else
            {
                var movie = context.Movies.ToList();
                return View("ReadOnlyMovies",movie);
            }
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
             
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canManageMovies")]
        public ActionResult Create(Movie NewMovie)
        {
            //if (!ModelState.IsValid)
            //{
            //    var newMovie = NewMovie;
            //    return View("Create", newMovie);
            //}
            if (NewMovie.ID == 0)
            {
                context.Movies.Add(NewMovie);
            }
            else
            {
                Movie UpdateMovie = context.Movies.FirstOrDefault(m => m.ID == NewMovie.ID);
                UpdateMovie.Name = NewMovie.Name;
                UpdateMovie.ReleaseDate = NewMovie.ReleaseDate;
                UpdateMovie.NumberInStock = NewMovie.NumberInStock;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "canManageMovies")]
        public ActionResult Edit(int id)
        {
            Movie EditMovie = context.Movies.FirstOrDefault(m => m.ID == id);
            return View("Create" , EditMovie);
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
        [HttpGet]
        [Authorize(Roles = "canManageMovies")]
        public ActionResult Delete(int? id)
        {
            Movie MovieInDb = context.Movies.Find(id);
            if (MovieInDb == null)
                return HttpNotFound();
            return View(MovieInDb);
        }

        [HttpPost]
        [Authorize(Roles = "canManageMovies")]
        public ActionResult Delete(int id)
        {
            Movie MovieInDb = context.Movies.Find(id);
            if (MovieInDb == null)
                return HttpNotFound();
            context.Movies.Remove(MovieInDb);
            context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

       
    }
}
