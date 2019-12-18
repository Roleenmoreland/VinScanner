using System.Threading.Tasks;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IDealerRepository
    {
        Task AddDealer(Dealer dealer);
        Task<Dealer> Get(int dealerId);
        Task<bool> CheckCredentials(string userName, string password);
        Task<bool> CheckAvailability(string userName, string emailAddress);

    }
}
