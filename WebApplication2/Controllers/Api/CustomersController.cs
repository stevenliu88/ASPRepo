using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using System.Web.Http;
using System.Data.Entity;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // Get /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                                .Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            var customerDtos  = customersQuery
                                .ToList()
                                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }
        // Get /api/customer/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }
        // Put /api/customer/1
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
        // Delete /api/customer/1
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
