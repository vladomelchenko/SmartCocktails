using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Models;
using API.Services;

namespace API.Controllers
{
    public class ClubsController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: api/Clubs
        public IQueryable<Club> GetClubs()
        {
            return new ClubService(_db).GetClubs();
        }

        // GET: api/Clubs/5
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> GetClub(int id)
        {
            Club club = await
                new ClubService(_db).GetClubAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }
        #region UnUseCode 
        //// PUT: api/Clubs/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutClub(int id, Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != club.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(club).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClubExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Clubs
        //[ResponseType(typeof(Club))]
        //public async Task<IHttpActionResult> PostClub(Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Clubs.Add(club);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = club.Id }, club);
        //}

        //// DELETE: api/Clubs/5
        //[ResponseType(typeof(Club))]
        //public async Task<IHttpActionResult> DeleteClub(int id)
        //{
        //    Club club = await db.Clubs.FindAsync(id);
        //    if (club == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Clubs.Remove(club);
        //    await db.SaveChangesAsync();

        //    return Ok(club);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ClubExists(int id)
        //{
        //    return db.Clubs.Count(e => e.Id == id) > 0;
        //}
#endregion
    }
}