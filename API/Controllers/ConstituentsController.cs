using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ConstituentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Constituents
        public IQueryable<Constituent> GetConstituents()
        {
            return db.Constituents;
        }

        // GET: api/Constituents/5
        [ResponseType(typeof(Constituent))]
        public async Task<IHttpActionResult> GetConstituent(int id)
        {
            Constituent constituent = await db.Constituents.FindAsync(id);
            if (constituent == null)
            {
                return NotFound();
            }

            return Ok(constituent);
        }

        // PUT: api/Constituents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConstituent(int id, Constituent constituent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != constituent.Id)
            {
                return BadRequest();
            }

            db.Entry(constituent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstituentExists(id))
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

        // POST: api/Constituents
        [ResponseType(typeof(Constituent))]
        public async Task<IHttpActionResult> PostConstituent(Constituent constituent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Constituents.Add(constituent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = constituent.Id }, constituent);
        }

        // DELETE: api/Constituents/5
        [ResponseType(typeof(Constituent))]
        public async Task<IHttpActionResult> DeleteConstituent(int id)
        {
            Constituent constituent = await db.Constituents.FindAsync(id);
            if (constituent == null)
            {
                return NotFound();
            }

            db.Constituents.Remove(constituent);
            await db.SaveChangesAsync();

            return Ok(constituent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConstituentExists(int id)
        {
            return db.Constituents.Count(e => e.Id == id) > 0;
        }
    }
}