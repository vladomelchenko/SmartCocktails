using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IIotService
    {
        IQueryable<Iot> GetIots();
        Task<Iot> GetIotsAsync(int id);
    }
}