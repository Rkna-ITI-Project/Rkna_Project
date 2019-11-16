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
    public class States_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/States_Table
        public IQueryable<States_Table> GetStates_Table()
        {
            return db.States_Table;
        }

        // GET: api/States_Table/5
        [ResponseType(typeof(States_Table))]
        public IHttpActionResult GetStates_Table(int id)
        {
            States_Table states_Table = db.States_Table.Find(id);
            if (states_Table == null)
            {
                return NotFound();
            }

            return Ok(states_Table);
        }

        // PUT: api/States_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStates_Table(int id, States_Table states_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != states_Table.States_ID)
            {
                return BadRequest();
            }

            db.Entry(states_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!States_TableExists(id))
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

        // POST: api/States_Table
        [ResponseType(typeof(States_Table))]
        public IHttpActionResult PostStates_Table(States_Table states_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.States_Table.Add(states_Table);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (States_TableExists(states_Table.States_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = states_Table.States_ID }, states_Table);
        }

        // DELETE: api/States_Table/5
        [ResponseType(typeof(States_Table))]
        public IHttpActionResult DeleteStates_Table(int id)
        {
            States_Table states_Table = db.States_Table.Find(id);
            if (states_Table == null)
            {
                return NotFound();
            }

            db.States_Table.Remove(states_Table);
            db.SaveChanges();

            return Ok(states_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool States_TableExists(int id)
        {
            return db.States_Table.Count(e => e.States_ID == id) > 0;
        }
    }
}