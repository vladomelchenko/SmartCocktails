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
    public class CocktailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cocktails
        public IQueryable<Cocktail> GetCocktails()
        {
            var cocktails = db.Cocktails;
            return cocktails;
        }

        // GET: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> GetCocktail(int id)
        {
            var cocktailConstituents = db.CocktailConstituetnses.Include(c => c.Constituent).Include(c=>c.Cocktail);
            foreach (var elem in cocktailConstituents)
            {
                elem.Constituent =await db.Constituents.FindAsync(elem.Constituent.Id);
            }
            Cocktail cocktail = await db.Cocktails.Include(c => cocktailConstituents).Include(c=>c.CocktailConstituents).FirstAsync(c => c.Id == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return Ok(cocktail);
        }

        // PUT: api/Cocktails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCocktail(int id, Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cocktail.Id)
            {
                return BadRequest();
            }

            db.Entry(cocktail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailExists(id))
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

        // POST: api/Cocktails
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> PostCocktail(Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cocktails.Add(cocktail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cocktail.Id }, cocktail);
        }

        // DELETE: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> DeleteCocktail(int id)
        {
            Cocktail cocktail = await db.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            db.Cocktails.Remove(cocktail);
            await db.SaveChangesAsync();

            return Ok(cocktail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CocktailExists(int id)
        {
            return db.Cocktails.Count(e => e.Id == id) > 0;
        }
    }
}