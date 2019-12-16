using System.Linq;
using VinScanner.Data;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;

namespace VinScanner.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private readonly VinScannerContext context;

        public DealerRepository()
        {
            context = new VinScannerContext();
        }

        public void AddDealer(Dealer dealer)
        {
            var newDealer = new Dealer()
            {
                UserName = dealer.UserName.ToLower(),
                Password = dealer.Password,
                EmailAddress = dealer.EmailAddress.ToLower()
            };
            context.Dealers.Add(newDealer);
            context.SaveChanges();

        }

        public bool CheckCredentials(string userName, string password)
        {
            var dealer = context.Dealers?.FirstOrDefault(d => d.UserName == userName.ToLower() && d.Password == password);
            if (dealer != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckAvailability(string userName, string emailAddress)
        {
            var dealer = context.Dealers?.FirstOrDefault(d => d.UserName == userName.ToLower() || d.EmailAddress == emailAddress.ToLower());
            if (dealer == null)
            {
                return true;
            }
            return false;
        }
    }
}
