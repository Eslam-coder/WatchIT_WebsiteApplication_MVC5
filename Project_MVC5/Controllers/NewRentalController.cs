using Project_MVC5.DTO;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC5.Controllers
{
    
    public class NewRentalController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult CreateNewRental()
        {
            
            return View(); 
        }
        // Post: /NewRental/CreateNewRental
        [HttpPost]
        public ActionResult CreateNewRental(NewRentalDto newRental)
        {
            Customer customerInDb = context.Customers.FirstOrDefault(c => c.ID == newRental.CustomerId);
            //Return List of movies
            var moviesInDb = context.Movies.Where(m => newRental.MovieId.Contains(m.ID));

            foreach (var item in moviesInDb)
            {
                if (item.NumberAvailable == 0)
                    return HttpNotFound("No Movie Available :(");
                item.NumberAvailable--;
                //Anonymouns Type(object)
                var Rental = new Rental
                {
                    Customer = customerInDb,
                    Movie = item,
                    DateRented = DateTime.Now
                };
                context.Rentals.Add(Rental);
            }
            context.SaveChanges();
            return View();
        }
    }
}