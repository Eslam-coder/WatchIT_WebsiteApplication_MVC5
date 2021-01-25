using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_MVC5.Models
{
    public class MembershipType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
       
    }
}