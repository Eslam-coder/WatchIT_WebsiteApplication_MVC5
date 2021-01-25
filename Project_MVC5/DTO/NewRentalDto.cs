using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_MVC5.DTO
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieId { get; set; }

    }
}