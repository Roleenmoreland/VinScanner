using VinScanner.Data;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;
using System.Linq;

namespace VinScanner.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly VinScannerContext context;
        public ClientRepository()
        {
            context = new VinScannerContext();
        }

        public Client GetClient(string name, int mobileNumber)
        {
            var client = context.Clients?.FirstOrDefault(c => c.Name == name && c.MobileNumber == mobileNumber);
            return client;
        }

        public Client AddClient(Client client)
        {
            var newClient = context.Clients.Add(client);
            context.SaveChanges();

            return client;
        }
    }
}
