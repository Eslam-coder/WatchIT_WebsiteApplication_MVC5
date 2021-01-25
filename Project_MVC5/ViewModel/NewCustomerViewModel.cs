using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_MVC5.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}