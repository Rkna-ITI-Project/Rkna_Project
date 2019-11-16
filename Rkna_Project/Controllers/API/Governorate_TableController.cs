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
    public class Governorate_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Governorate_Table
        public IQueryable<Governorate_Table> GetGovernorate_Table()
        {
            return db.Governorate_Table;
        }

        // GET: api/Governorate_Table/5
        [ResponseType(typeof(Governorate_Table))]
        public IHttpActionResult GetGovernorate_Table(int id)
        {
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            if (governorate_Table == null)
            {
                return NotFound();
            }

            return Ok(governorate_Table);
        }

        // PUT: api/Governorate_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGovernorate_Table(int id, Governorate_Table governorate_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != governorate_Table.Gov_ID)
            {
                return BadRequest();
            }

            db.Entry(governorate_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Governorate_TableExists(id))
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

        // POST: api/Governorate_Table
        [ResponseType(typeof(Governorate_Table))]
        public IHttpActionResult PostGovernorate_Table(Governorate_Table governorate_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Governorate_Table.Add(governorate_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = governorate_Table.Gov_ID }, governorate_Table);
        }

        // DELETE: api/Governorate_Table/5
        [ResponseType(typeof(Governorate_Table))]
        public IHttpActionResult DeleteGovernorate_Table(int id)
        {
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            if (governorate_Table == null)
            {
                return NotFound();
            }

            db.Governorate_Table.Remove(governorate_Table);
            db.SaveChanges();

            return Ok(governorate_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Governorate_TableExists(int id)
        {
            return db.Governorate_Table.Count(e => e.Gov_ID == id) > 0;
        }
    }
}