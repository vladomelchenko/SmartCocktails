using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Models;
using API.Services;

namespace API.Controllers
{
    public class IotsController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public IQueryable<Iot> GetIots()
        {
            return new IotService(_db).GetIots();
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetIot(int id)
        {
            Iot iot = await new IotService(_db).GetIotsAsync(id);
            if (iot == null)
            {
                return NotFound();
            }

            return Ok(iot);
        }
    }
}
