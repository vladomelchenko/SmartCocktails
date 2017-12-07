using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Models;
using API.Services.Interfaces;

namespace API.Services
{
    public class ClubService : IClubService
    {
        private ApplicationDbContext _db;

        public ClubService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Club> GetClubs()
        {
            return _db.Clubs.Include(c => c.City);
        }

        public async Task<Club> GetClubAsync(City city)
        {
            var club = await _db.Clubs.Include(c => c.City).FirstOrDefaultAsync(c => c.City == city);
            return club;
        }

        public async Task<Club> GetClubAsync(int id)
        {

            var club = await _db.Clubs.Include(c => c.City).FirstOrDefaultAsync(c => c.Id == id);
            return club;
        }
    }
}