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
    public class Car_Specifications_TableController : ApiController
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: api/Car_Specifications_Table
        public IQueryable<Car_Specifications_Table> GetCar_Specifications_Table()
        {
            return db.Car_Specifications_Table;
        }

        // GET: api/Car_Specifications_Table/5
        [ResponseType(typeof(Car_Specifications_Table))]
        public IHttpActionResult GetCar_Specifications_Table(int id)
        {
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            if (car_Specifications_Table == null)
            {
                return NotFound();
            }

            return Ok(car_Specifications_Table);
        }

        // PUT: api/Car_Specifications_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar_Specifications_Table(int id, Car_Specifications_Table car_Specifications_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car_Specifications_Table.Car_Spe_ID)
            {
                return BadRequest();
            }

            db.Entry(car_Specifications_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Car_Specifications_TableExists(id))
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

        // POST: api/Car_Specifications_Table
        [ResponseType(typeof(Car_Specifications_Table))]
        public IHttpActionResult PostCar_Specifications_Table(Car_Specifications_Table car_Specifications_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Car_Specifications_Table.Add(car_Specifications_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car_Specifications_Table.Car_Spe_ID }, car_Specifications_Table);
        }

        // DELETE: api/Car_Specifications_Table/5
        [ResponseType(typeof(Car_Specifications_Table))]
        public IHttpActionResult DeleteCar_Specifications_Table(int id)
        {
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            if (car_Specifications_Table == null)
            {
                return NotFound();
            }

            db.Car_Specifications_Table.Remove(car_Specifications_Table);
            db.SaveChanges();

            return Ok(car_Specifications_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Car_Specifications_TableExists(int id)
        {
            return db.Car_Specifications_Table.Count(e => e.Car_Spe_ID == id) > 0;
        }
    }
}