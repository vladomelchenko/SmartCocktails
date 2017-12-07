using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using Microsoft.Owin.Security.Provider;

namespace API.Services
{
    public class CocktailService : ICocktailService
    {
        private ApplicationDbContext _db;

        public CocktailService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Cocktail> GetCocktailAsync(int id)
        {
            var cocktailConstituents = _db.CocktailConstituetnses.Include(c => c.Constituent).Include(c => c.Cocktail);
            foreach (var elem in cocktailConstituents)
            {
                elem.Constituent = await _db.Constituents.FindAsync(elem.Constituent.Id);
                
            }
            Cocktail cocktail = await _db.Cocktails.Include(c => c.CocktailConstituents).FirstAsync(c => c.Id == id);
            foreach (var elem in cocktail.CocktailConstituents)
            {
                elem.Constituent.CocktailConstituents = null;
            }
            if (cocktail == null)
            {
                return null;
            }

            return cocktail;
        }

        public IQueryable<Cocktail> GetCocktails()
        {
            var cocktails = _db.Cocktails;
            return cocktails;
        }
    }
}