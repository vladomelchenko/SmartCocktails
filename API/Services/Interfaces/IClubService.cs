using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IClubService
    {
        IQueryable<Club> GetClubs();
        Task<Club> GetClubAsync(City city);
        Task<Club> GetClubAsync(int id);
    }
}