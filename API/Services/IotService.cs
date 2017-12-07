using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using System.Data.Entity;

namespace API.Services
{
    public class IotService:IIotService
    {
        private ApplicationDbContext _db;

        public IotService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Iot> GetIots()
        {
            var clubs = _db.Clubs.Include(c => c.City);
            var iots = _db.Iots.Include(i => i.Club).Include(c=>c.Club.City).Include(i=>i.IotConstituents);
            return iots;
        }

        public async Task<Iot> GetIotsAsync(int id)
        {
            var clubs = _db.Clubs.Include(c => c.City);
            var iots = _db.Iots.Include(i => i.Club).Include(i=>i.Club.City).Include(i=>i.IotConstituents);
            var iot = await iots.FirstOrDefaultAsync(i => i.Id == id);
            return iot;
        }
    }
}