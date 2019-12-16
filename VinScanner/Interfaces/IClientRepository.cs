using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IClientRepository
    {
        Client GetClient(string name, int mobileNumber);
        Client AddClient(Client client);
    }
}
