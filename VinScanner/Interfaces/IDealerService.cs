using VinScanner.Models;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IDealerService
    {
        bool Login(string username, string password);
        bool Register(Dealer dealer);
        bool RequestVechileDetails(RequestVechilDetails request);
    }
}
