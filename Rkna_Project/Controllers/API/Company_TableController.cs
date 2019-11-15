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
    public class Company_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Company_Table
        public IQueryable<Company_Table> GetCompany_Table()
        {
            return db.Company_Table;
        }

        // GET: api/Company_Table/5
        [ResponseType(typeof(Company_Table))]
        public IHttpActionResult GetCompany_Table(int id)
        {
            Company_Table company_Table = db.Company_Table.Find(id);
            if (company_Table == null)
            {
                return NotFound();
            }

            return Ok(company_Table);
        }

        // PUT: api/Company_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany_Table(int id, Company_Table company_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company_Table.Company_Info_ID)
            {
                return BadRequest();
            }

            db.Entry(company_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Company_TableExists(id))
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

        // POST: api/Company_Table
        [ResponseType(typeof(Company_Table))]
        public IHttpActionResult PostCompany_Table(Company_Table company_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Company_Table.Add(company_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company_Table.Company_Info_ID }, company_Table);
        }

        // DELETE: api/Company_Table/5
        [ResponseType(typeof(Company_Table))]
        public IHttpActionResult DeleteCompany_Table(int id)
        {
            Company_Table company_Table = db.Company_Table.Find(id);
            if (company_Table == null)
            {
                return NotFound();
            }

            db.Company_Table.Remove(company_Table);
            db.SaveChanges();

            return Ok(company_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Company_TableExists(int id)
        {
            return db.Company_Table.Count(e => e.Company_Info_ID == id) > 0;
        }
    }
}