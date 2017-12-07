using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Async;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICocktailService
    {
        IQueryable<Cocktail> GetCocktails();
        Task<Cocktail> GetCocktailAsync(int id);
    }
}