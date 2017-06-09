using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

      
        public IHttpActionResult GetCustomers()
        {

            // return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);


            var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);


            return Ok(customerDtos); 

        }

    


        //GET api/customer/1
        //public CustomerDto GetCustomer(int id)
        //{

        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    return Mapper.Map<Customer,CustomerDto>(customer);

        //}

        public IHttpActionResult GetCustomer(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            //if (customer == null)
            //    return NotFound();

            //return Ok(Mapper.Map<Customer, CustomerDto>(customer));


            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);

            //}
            //var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        
            //_context.Customers.Add(customer);
            //_context.SaveChanges();

            //customerDto.Id = customer.Id;
            //return customerDto;


            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }


        //[HttpPut]
        //public void UpdateCustomer(int id, CustomerDto customerDto)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    }
        //    var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (custInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    //cust.Name = customer.Name;
        //    //cust.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        //    //cust.BirthDate = customer.BirthDate;
        //    //cust.MembershipTypeId = customer.MembershipTypeId;


        //    Mapper.Map(customerDto, custInDb);
        //    _context.SaveChanges();

        //}


        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }


        //[HttpDelete]
        //public void DeleteCustomer(int id, Customer customer)
        //{

        //    var cust = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (cust == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    _context.Customers.Remove(cust);

        //    _context.SaveChanges();
        //}


        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }


}