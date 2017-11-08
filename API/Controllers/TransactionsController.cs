using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using Microsoft.AspNet.Identity;

namespace API.Controllers
{
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Constituents
        public IQueryable<Transaction> GetConstituents(string token)
        {

            return db.Transactions.Include(t => t.User).Include(t => t.Cocktail);
        }

        // GET: api/Constituents/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> GetConstituent(int id)
        {
            Transaction transaction = await db.Transactions.Include(t => t.Cocktail).Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/Constituents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConstituent(int id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.Id)
            {
                return BadRequest();
            }

            db.Entry(transaction).State = EntityState.Modified;

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
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> PostConstituent(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = db.Users.First(u => u == transaction.User);
            var userBalance = user.Balance;
            if (userBalance < transaction.Cocktail.Price)
            {
                return BadRequest();
            }
            user.Balance -= transaction.Cocktail.Price;
            db.Entry(user).State = EntityState.Modified;
            db.Transactions.Add(transaction);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Constituents/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> DeleteConstituent(int id)
        {
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            db.Transactions.Remove(transaction);
            await db.SaveChangesAsync();

            return Ok(transaction);
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
