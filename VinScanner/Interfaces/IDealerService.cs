using System.Threading.Tasks;
using VinScanner.Models;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IDealerService
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(Dealer dealer);
        Task<bool> RequestVechileDetails(User request);
    }
}
