using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using System.Data.Entity;

namespace API.Services
{
    public class ConstituentService:IConstituentService
    {
        private ApplicationDbContext _db;
        public ConstituentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<Constituent> GetConstituents()
        {
            return _db.Constituents;
        }

        public async Task<Constituent> GetConstituentAsync(int id)
        {
            var constituent = await _db.Constituents.FirstAsync(c=>c.Id == id);
            return constituent;
        }
        public IEnumerable<Cocktail> GetCocktailsByConstituentId(int constituentId)
        {
            var cocktailConstituents = _db.CocktailConstituetnses.Include(c => c.Constituent).Include(c => c.Cocktail)
                .Where(c => c.Constituent.Id == constituentId);
            foreach (var elem in cocktailConstituents)
            {
                if (elem.Constituent.Id == constituentId)
                {
                    var cocktail = elem.Cocktail;
                    cocktail.CocktailConstituents = null;
                    yield return cocktail;
                }
            }
        }
    }
}