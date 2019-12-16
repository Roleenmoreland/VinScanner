using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IDealerRepository
    {
        void AddDealer(Dealer dealer);
        bool CheckCredentials(string userName, string password);
        bool CheckAvailability(string userName, string emailAddress);

    }
}
