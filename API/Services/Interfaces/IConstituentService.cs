using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IConstituentService
    {
        IQueryable<Constituent> GetConstituents();
        Task<Constituent> GetConstituentAsync(int id);
        IEnumerable<Cocktail> GetCocktailsByConstituentId(int constituentId);
    }
}