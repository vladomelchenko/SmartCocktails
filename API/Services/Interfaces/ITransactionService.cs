using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ITransactionService
    {
        IQueryable<Transaction> GetTransactions(string userId);
        Task<Transaction> GetTransactionAsync(int id);
        Task<Transaction> PostTransactionAsync(Transaction transaction);
        Task<Transaction> DeleteTransactionAsync(int id);
    }
}