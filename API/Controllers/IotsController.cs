using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class IotsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Iot> GetIots()
        {
            return db.Iots.Include(i => i.Club).Include(i => i.IotConstituents);
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetIot(int id)
        {
            Iot iot = await db.Iots.Include(i => i.Club).Include(i => i.IotConstituents)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (iot == null)
            {
                return NotFound();
            }

            return Ok(iot);
        }
    }
}
