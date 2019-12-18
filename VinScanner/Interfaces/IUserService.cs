using System.Threading.Tasks;
using VinScanner.Models;

namespace VinScanner.Interfaces
{
    public interface IUserService
    {
        Task<bool> SendVechileDetails(SendVechileDetailsRequest request);
    }
}
