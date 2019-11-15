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
    public class Slut_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Slut_Table
        public IQueryable<Slut_Table> GetSlut_Table()
        {
            return db.Slut_Table;
        }

        // GET: api/Slut_Table/5
        [ResponseType(typeof(Slut_Table))]
        public IHttpActionResult GetSlut_Table(int id)
        {
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            if (slut_Table == null)
            {
                return NotFound();
            }

            return Ok(slut_Table);
        }

        // PUT: api/Slut_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlut_Table(int id, Slut_Table slut_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slut_Table.Slut_ID)
            {
                return BadRequest();
            }

            db.Entry(slut_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Slut_TableExists(id))
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

        // POST: api/Slut_Table
        [ResponseType(typeof(Slut_Table))]
        public IHttpActionResult PostSlut_Table(Slut_Table slut_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Slut_Table.Add(slut_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = slut_Table.Slut_ID }, slut_Table);
        }

        // DELETE: api/Slut_Table/5
        [ResponseType(typeof(Slut_Table))]
        public IHttpActionResult DeleteSlut_Table(int id)
        {
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            if (slut_Table == null)
            {
                return NotFound();
            }

            db.Slut_Table.Remove(slut_Table);
            db.SaveChanges();

            return Ok(slut_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Slut_TableExists(int id)
        {
            return db.Slut_Table.Count(e => e.Slut_ID == id) > 0;
        }
    }
}