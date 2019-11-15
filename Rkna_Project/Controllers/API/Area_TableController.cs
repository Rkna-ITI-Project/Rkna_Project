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
    public class Area_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Area_Table
        public IQueryable<Area_Table> GetArea_Table()
        {
            return db.Area_Table;
        }

        // GET: api/Area_Table/5
        [ResponseType(typeof(Area_Table))]
        public IHttpActionResult GetArea_Table(int id)
        {
            Area_Table area_Table = db.Area_Table.Find(id);
            if (area_Table == null)
            {
                return NotFound();
            }

            return Ok(area_Table);
        }

        // PUT: api/Area_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArea_Table(int id, Area_Table area_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != area_Table.Area_ID)
            {
                return BadRequest();
            }

            db.Entry(area_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Area_TableExists(id))
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

        // POST: api/Area_Table
        [ResponseType(typeof(Area_Table))]
        public IHttpActionResult PostArea_Table(Area_Table area_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Area_Table.Add(area_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = area_Table.Area_ID }, area_Table);
        }

        // DELETE: api/Area_Table/5
        [ResponseType(typeof(Area_Table))]
        public IHttpActionResult DeleteArea_Table(int id)
        {
            Area_Table area_Table = db.Area_Table.Find(id);
            if (area_Table == null)
            {
                return NotFound();
            }

            db.Area_Table.Remove(area_Table);
            db.SaveChanges();

            return Ok(area_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Area_TableExists(int id)
        {
            return db.Area_Table.Count(e => e.Area_ID == id) > 0;
        }
    }
}