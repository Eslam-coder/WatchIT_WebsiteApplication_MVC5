using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_MVC5.Models
{
    public class Rental
    {
        public int ID { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}