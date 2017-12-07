using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Models;
using API.Services;
using Microsoft.AspNet.Identity;

namespace API.Controllers
{
    [Authorize]
    public class BalanceController : ApiController
    {
        [HttpPost]
        [Route("api/Balance")]
        public async Task<IHttpActionResult> RechangeBalance(double sum)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var id = RequestContext.Principal.Identity.GetUserId();
            var userService = new UserService(db);
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            var resUser = await userService.BalanceRechange(sum, user);
            return Ok(resUser);
        }
    }
}
