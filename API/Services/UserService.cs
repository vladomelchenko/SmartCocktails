using System;
using System.Data.Entity;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;

namespace API.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> BalanceRechange(double sum,ApplicationUser user)
        {
            user.Balance += sum;
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return user;
        }
    }
}