using Project_MVC5.DTO;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace Project_MVC5.Controllers.API
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();


        //Get  /api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        #region GetById /api/Customers/1 
        //GetById /api/Customers/1
        //public CustomerDto customer(int id)
        //{
        //   Customer customerById = context.Customers.Find(id);

        //    if (customerById == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map<Customer,CustomerDto>(customerById);
        //}
        #endregion

        //GetById /api/Customers/1
        [HttpGet]
        public IHttpActionResult customer(int id)
        {
            Customer customerById = context.Customers.Find(id);

            if (customerById == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerById));
        }

        #region  //Post /api/Customers
        //Post /api/Customers
        //[HttpPost]
        //public CustomerDto CreateCustomer(CustomerDto NewCustomerDto)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var NewCustomer = Mapper.Map<CustomerDto, Customer>(NewCustomerDto);
        //    context.Customers.Add(NewCustomer);
        //    context.SaveChanges();
        //    return NewCustomerDto;
        //}
        #endregion

        //Post /api/Customers
        [HttpPost]
        public IHttpActionResult CreateNewCustomer (CustomerDto NewCustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var NewCustomer = Mapper.Map<CustomerDto, Customer>(NewCustomerDto);
            context.Customers.Add(NewCustomer);
            context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+NewCustomer.ID), NewCustomerDto);
        }

        #region  //Put /api/controllers
        //Put /api/controllers
        //[HttpPut]
        //public void EditCustomer(int id, CustomerDto UpdateCustomer)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    Customer CustomerInDb = context.Customers.Find(id);

        //    if (CustomerInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    Mapper.Map(UpdateCustomer, CustomerInDb);

        //    context.SaveChanges();

        //}
        #endregion

        //Put /api/controllers
        [HttpPut]
        public IHttpActionResult EditCustomer(int id , CustomerDto UpdateCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Customer CustomerInDb = context.Customers.Find(id);

            if (CustomerInDb == null)
                return NotFound();
            Mapper.Map(UpdateCustomer, CustomerInDb);
           
            context.SaveChanges();
            return Ok(CustomerInDb);
        }

        #region   //Delete /api/Customers
        ////Delete /api/Customers
        //[HttpDelete]
        //public void RemoveCustomer(int id)
        //{
        //    Customer CustomerInDb = context.Customers.Find(id);
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    context.Customers.Remove(CustomerInDb);
        //    context.SaveChanges();

        //}
        #endregion

        //Delete /api/Customers
        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int id)
        {
           Customer CustomerInDb = context.Customers.Find(id);
            if (!ModelState.IsValid)
                return BadRequest();

            context.Customers.Remove(CustomerInDb);
            context.SaveChanges();
            return Ok();
          
        }
    }
}
