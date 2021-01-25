using Project_MVC5.DTO;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_MVC5.Controllers.API
{
    public class NewRentalController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        //Post : /NewrENTAL/CreateNewRental
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            Customer CustomerInDb = context.Customers.Find(newRental.CustomerId);
            var MoviesInDb = context.Movies.Where(m => newRental.MovieId.Contains(m.ID));
            
            foreach (var item in MoviesInDb)
            {
                if(item.NumberAvailable==0)
                {
                    return BadRequest("No Movie Available :(");
                }
                item.NumberAvailable--;
                var Rental = new Rental
                {
                    Customer = CustomerInDb,
                    Movie = item,
                    DateRented = DateTime.Now
                };
                context.Rentals.Add(Rental);
            }
            context.SaveChanges();
            return Ok();
        }
    }
}
