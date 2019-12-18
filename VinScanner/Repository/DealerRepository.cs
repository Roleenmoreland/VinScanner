using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
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

        public async Task AddDealer(Dealer dealer)
        {
            var newDealer = new Dealer()
            {
                UserName = dealer.UserName.ToLower(),
                Password = dealer.Password,
                EmailAddress = dealer.EmailAddress.ToLower()
            };
            await context.Dealers.AddAsync(newDealer);
            await context.SaveChangesAsync();

        }

        public async Task<Dealer> Get(int dealerId)
        {
            var dealer = await context.Dealers?.FirstOrDefaultAsync(d => d.DealerId == dealerId);
            if (dealer != null)
            {
                return dealer;
            }
            throw new ApplicationException("Could not find the dealer");
        }

        public async Task<bool> CheckCredentials(string userName, string password)
        {
            var dealer = await context.Dealers?.FirstOrDefaultAsync(d => d.UserName == userName.ToLower() && d.Password == password);
            if (dealer != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckAvailability(string userName, string emailAddress)
        {
            var dealer = await context.Dealers?.FirstOrDefaultAsync(d => d.UserName == userName.ToLower() || d.EmailAddress == emailAddress.ToLower());
            if (dealer == null)
            {
                return true;
            }
            return false;
        }
    }
}
