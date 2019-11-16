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
using Rkna_Project.Models;

namespace Rkna_Project.Controllers.API
{
    public class Customer_Slut_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Customer_Slut_Table
        public IQueryable<Customer_Slut_Table> GetCustomer_Slut_Table()
        {
            return db.Customer_Slut_Table;
        }

        // GET: api/Customer_Slut_Table/5
        [ResponseType(typeof(Customer_Slut_Table))]
        public IHttpActionResult GetCustomer_Slut_Table(int id)
        {
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            if (customer_Slut_Table == null)
            {
                return NotFound();
            }

            return Ok(customer_Slut_Table);
        }

        // PUT: api/Customer_Slut_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer_Slut_Table(int id, Customer_Slut_Table customer_Slut_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer_Slut_Table.Customer_Slut_ID)
            {
                return BadRequest();
            }

            db.Entry(customer_Slut_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_Slut_TableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customer_Slut_Table
        [ResponseType(typeof(Customer_Slut_Table))]
        public IHttpActionResult PostCustomer_Slut_Table(Customer_Slut_Table customer_Slut_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customer_Slut_Table.Add(customer_Slut_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer_Slut_Table.Customer_Slut_ID }, customer_Slut_Table);
        }

        // DELETE: api/Customer_Slut_Table/5
        [ResponseType(typeof(Customer_Slut_Table))]
        public IHttpActionResult DeleteCustomer_Slut_Table(int id)
        {
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            if (customer_Slut_Table == null)
            {
                return NotFound();
            }

            db.Customer_Slut_Table.Remove(customer_Slut_Table);
            db.SaveChanges();

            return Ok(customer_Slut_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Customer_Slut_TableExists(int id)
        {
            return db.Customer_Slut_Table.Count(e => e.Customer_Slut_ID == id) > 0;
        }
    }
}