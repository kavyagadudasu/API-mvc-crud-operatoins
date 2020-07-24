using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUD.Operatins.Sample.Models;

namespace CRUD.Operatins.Sample.Controllers
{
    public class CustomersController : ApiController
    {
        //private CustomersEntities db = new CustomersEntities();

        //// GET: api/Customers
        //public List<Customer> GetCustomers()
        //{
        //    return db.Customers.ToList();
        //}

        //// GET: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult GetCustomer(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(customer);
        //}

        //// PUT: api/Customers/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCustomer(int id, Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Customers
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult PostCustomer(Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Customers.Add(customer);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CustomerExists(customer.CustomerId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        //}

        // DELETE: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult DeleteCustomer(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Customers.Remove(customer);
        //    db.SaveChanges();

        //    return Ok(customer);
        //}


        [Route("api/Customers/InsertCustomer")]
        [HttpPost]
        public Customer InsertCustomer(Customer _customer)
        {
            using (CustomersEntities1 entities = new CustomersEntities1())
            {
                entities.Customers.Add(_customer);
                entities.SaveChanges();
            }

            return _customer;
        }

        [Route("api/Customers/UpdateCustomer")]
        [HttpPost]
        public bool UpdateCustomer(Customer _customer)
        {
            using (CustomersEntities1 entities = new CustomersEntities1())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == _customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.Name = _customer.Name;
                updatedCustomer.Country = _customer.Country;
                entities.SaveChanges();
            }

            return true;
        }

        [Route("api/Customers/DeleteCustomer")]
        [HttpPost]
        public void DeleteCustomer(Customer _customer)
        {
            using (CustomersEntities1 entities = new CustomersEntities1())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == _customer.CustomerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerExists(int id)
        //{
        //    return db.Customers.Count(e => e.CustomerId == id) > 0;
        //}
    }
}