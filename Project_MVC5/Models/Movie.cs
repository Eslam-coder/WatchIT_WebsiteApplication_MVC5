using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_MVC5.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required (ErrorMessage ="Name Is Required")]
        public string Name { get; set; }

        [Display (Name ="Release Date")]
        [Required (ErrorMessage ="Release Date is Required")]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Number in stock")]
        [Required(ErrorMessage = "Number in stock is required")]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }


    }
}