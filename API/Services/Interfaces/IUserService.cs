using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> BalanceRechange(double sum, ApplicationUser user);
    }
}