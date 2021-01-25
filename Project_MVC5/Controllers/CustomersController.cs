using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project_MVC5.ViewModel;
namespace Project_MVC5.Controllers
{
    [Authorize (Roles ="canManageMovies")]
    public class CustomersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();


        // GET: Customers
        
        public ActionResult Index()
        {
            //eager Execution
            var customer = context.Customers.Include(c => c.MembershipType).ToList();

            return View(customer);
        }

        public ActionResult New()
        {
            var MembershipType = context.MembershipType.ToList();
            var NewCustomerViewModel = new NewCustomerViewModel
            {
                MembershipTypes = MembershipType
            };
            
            return View("New",NewCustomerViewModel);
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            Customer customerDetail = context.Customers.FirstOrDefault(c => c.ID == id);
            return View(customerDetail);
        }


        
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                var CustomerValidate = new NewCustomerViewModel
                {
                    Customer = Customer,                   
                    MembershipTypes = context.MembershipType.ToList()

                };
                return View("New", CustomerValidate);
            }

            if (Customer.ID == 0)
               {
                context.Customers.Add(Customer);
               }
               else
               {
               Customer Updatecustomer = context.Customers.FirstOrDefault(c => c.ID == Customer.ID);
                Updatecustomer.Name = Customer.Name;
                Updatecustomer.MembershipTypeId = Customer.MembershipTypeId;
                Updatecustomer.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
                Updatecustomer.ID = Customer.ID;
               }
          
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

      

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var Customer = context.Customers.FirstOrDefault(c => c.ID == id);
            var CustomerEdit = new NewCustomerViewModel
            {
                Customer = Customer,
                MembershipTypes = context.MembershipType.ToList()
            };
            return View("New", CustomerEdit);
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            Customer CustomerInDb = context.Customers.Find(id);
            var CustomerDelete = new NewCustomerViewModel
            {
                Customer = CustomerInDb,
                MembershipTypes = context.MembershipType.ToList()
            };
            
            return View(CustomerDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           Customer customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

      
    }
}
