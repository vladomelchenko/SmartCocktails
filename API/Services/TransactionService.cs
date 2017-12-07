using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;
using API.Models;
using API.Services.Interfaces;

namespace API.Services
{
    public class TransactionService : ITransactionService
    {
        private ApplicationDbContext _db;

        public TransactionService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Transaction> DeleteTransactionAsync(int id)
        {
            Transaction transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return null;
            }

            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            Transaction transaction = await _db.Transactions.Include(t => t.Cocktail).Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            return transaction;
        }

        public IQueryable<Transaction> GetTransactions(string userId)
        {
            var transactions = _db.Transactions.Include(t => t.Cocktail).Where(t => t.User.Id == userId);
            return transactions;
        }

        public async Task<Transaction> PostTransactionAsync(Transaction transaction)
        {
            var user = transaction.User;
            _db.Entry(user).State = EntityState.Modified;
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
            return transaction;
        }
    }
}