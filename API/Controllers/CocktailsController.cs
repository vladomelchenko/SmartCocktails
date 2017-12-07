using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Models;
using API.Services;
using API.Services.Interfaces;

namespace API.Controllers
{
    public class CocktailsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Cocktails
        public IQueryable<Cocktail> GetCocktails()
        {
            CocktailService cocktailService = new CocktailService(_db);
            return cocktailService.GetCocktails();
        }

        // GET: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> GetCocktail(int id)
        {
            CocktailService cocktailService = new CocktailService(_db);
            var cocktail = await cocktailService.GetCocktailAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return Ok(cocktail);
        }


        #region NotUseableFunc

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

            _db.Entry(cocktail).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
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

            _db.Cocktails.Add(cocktail);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cocktail.Id }, cocktail);
        }

        // DELETE: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> DeleteCocktail(int id)
        {
            Cocktail cocktail = await _db.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            _db.Cocktails.Remove(cocktail);
            await _db.SaveChangesAsync();

            return Ok(cocktail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CocktailExists(int id)
        {
            return _db.Cocktails.Count(e => e.Id == id) > 0;
        }

        #endregion
    }
}