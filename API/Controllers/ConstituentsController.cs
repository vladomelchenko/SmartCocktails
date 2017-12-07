using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using API.Services;
using API.Services.Interfaces;

namespace API.Controllers
{
    public class ConstituentsController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        [Route("api/Constituents/Cocktail")]
        [ResponseType(typeof(IEnumerable<Cocktail>))]
        public IEnumerable<Cocktail> GetCocktailByConstituent(int constituentId)
        {
            IConstituentService cocktailService = new ConstituentService(_db);
            return  cocktailService.GetCocktailsByConstituentId(constituentId);
        }

        // GET: api/Constituents
        [ResponseType(typeof(IQueryable<Constituent>))]
        public IQueryable<Constituent> GetConstituents()
        {
            IConstituentService constituentService = new ConstituentService(_db);
            return constituentService.GetConstituents();
        }

        // GET: api/Constituents/5
        [ResponseType(typeof(Cocktail))]
        public async Task<IHttpActionResult> GetCocktail(int id)
        {
            IConstituentService constituentService = new ConstituentService(_db);
            var constituent = await constituentService.GetConstituentAsync(id);
            if (constituent == null)
            {
                return NotFound();
            }

            return Ok(constituent);
        }
    }
}
