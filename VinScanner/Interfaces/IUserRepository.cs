using System.Threading.Tasks;
using VinScanner.Models.Repository;

namespace VinScanner.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string name, string mobileNumber);
        Task<User> GetUser(int userId);
        Task<User> AddUser(User user);
    }
}
