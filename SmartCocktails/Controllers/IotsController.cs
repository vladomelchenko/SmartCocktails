using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCocktails.Models;

namespace SmartCocktails.Controllers
{
    public class IotsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Iots
        public IQueryable<Iot> GetIots()
        {
            return db.Iots;
        }

        // GET: api/Iots/5
        [ResponseType(typeof(Iot))]
        public IHttpActionResult GetIot(int id)
        {
            Iot iot = db.Iots.Find(id);
            if (iot == null)
            {
                return NotFound();
            }

            return Ok(iot);
        }

        // PUT: api/Iots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIot(int id, Iot iot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iot.Id)
            {
                return BadRequest();
            }

            db.Entry(iot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IotExists(id))
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

        // POST: api/Iots
        [ResponseType(typeof(Iot))]
        public IHttpActionResult PostIot(Iot iot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Iots.Add(iot);
            IEnumerable<Constituent> Constituents = iot.Constituents;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iot.Id }, iot);
        }

        // DELETE: api/Iots/5
        [ResponseType(typeof(Iot))]
        public IHttpActionResult DeleteIot(int id)
        {
            Iot iot = db.Iots.Find(id);
            if (iot == null)
            {
                return NotFound();
            }

            db.Iots.Remove(iot);
            db.SaveChanges();

            return Ok(iot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IotExists(int id)
        {
            return db.Iots.Count(e => e.Id == id) > 0;
        }
    }
}