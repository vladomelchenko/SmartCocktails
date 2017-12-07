using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Models;
using Microsoft.AspNet.Identity;
using API.Services;

namespace API.Controllers
{   
    [Authorize]
    public class TransactionsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/Constituents
        public IQueryable<Transaction> GetTransactions()
        {
            var id = RequestContext.Principal.Identity.GetUserId();
            TransactionService transactionService = new TransactionService(_db);
            var transactions = transactionService.GetTransactions(id);
            return transactions;
        }

        // GET: api/Constituents/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> GetTransaction(int id)
        {
            var transaction = await new TransactionService(_db).GetTransactionAsync(id);
            if (transaction == null)
            {
                return BadRequest();
            }

            return Ok(transaction);
        }

      
        // POST: api/Constituents
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var id = RequestContext.Principal.Identity.GetUserId();
                transaction.User = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
                transaction.Cocktail = await _db.Cocktails.FirstOrDefaultAsync(c => c.Id == transaction.Cocktail.Id);
                if (transaction.User.Balance < transaction.Cocktail.Price)
                {
                    return BadRequest();
                }
                transaction.User.Balance -= transaction.Cocktail.Price;
                transaction.Date = DateTime.Now;
                TransactionService transactionService = new TransactionService(_db);
                await transactionService.PostTransactionAsync(transaction);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Constituents/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> DeleteTransaction(int id)
        {
            var transaction = await new TransactionService(_db).DeleteTransactionAsync(id);
            if (transaction == null)
            {
                return BadRequest();
            }
            return Ok(transaction);
        }
    }
}
