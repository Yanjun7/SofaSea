﻿
using SofaSea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SofaSea.Dtos;
using AutoMapper;
using System.Data.Entity;


namespace SofaSea.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            var customersDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customersDtos);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.ID = customer.ID;
            return Created(new Uri(Request.RequestUri + "/" + customer.ID),customerDto);
        }

        [HttpPut]
        //PUT /api/customers/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
