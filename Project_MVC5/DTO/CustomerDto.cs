using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project_MVC5.Models;

namespace Project_MVC5.DTO
{
    public class CustomerDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Name!")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
       
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}