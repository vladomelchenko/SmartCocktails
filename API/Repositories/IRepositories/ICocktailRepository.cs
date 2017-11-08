using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using API.Models;

namespace API.Repositories.IRepositories
{
    public interface ICocktailRepository
    {
        IEnumerable<Cocktail> GetAllAsync();
        Cocktail GetCocktail(int id);
        Task AddAsync(Cocktail c);
        IHttpActionResult PutCocktail(int id,Cocktail c);
        IHttpActionResult DeleteCocktail(int id);
    }
}