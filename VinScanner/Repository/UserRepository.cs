using VinScanner.Data;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VinScanner.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly VinScannerContext context;
        public UserRepository()
        {
            context = new VinScannerContext();
        }

        public async Task<User> GetUser(string name, string mobileNumber)
        {
            var user = await context.Users?.FirstOrDefaultAsync(c => c.Name == name && c.MobileNumber == mobileNumber);
            return user;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await context.Users?.FirstOrDefaultAsync(c => c.UserId == userId);
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            var newClient = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

    }
}
